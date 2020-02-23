using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using FennyFeeds.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [Authorize]
    [SessionTimeout]
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private _IAllRepository<FF_Products> interfaceobj;
        private _IAllRepository<FF_Product_SubTable> interfaceobj_Product_SubTable;
        //private _IAllRepository<FF_Category> interfaceobj_Category;

        public ProductController()
        {
            this.interfaceobj = new AllRepository<FF_Products>();
            this.interfaceobj_Product_SubTable = new AllRepository<FF_Product_SubTable>();
            //this.interfaceobj_Category = new AllRepository<FF_Category>();
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddProduct()
        {
            using (DataContext dc = new DataContext())
            {
                var catlist = dc.FF_Category.ToList();
                ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category", "Select Category");

                var variantlist = dc.FF_Product_Variants.ToList();
                ViewBag.Dropdown_Variant = new SelectList(variantlist, "ID", "Variants_Name", "Select Variant");

                //var subcategorylist = dc.FF_Sub_Category.ToList();
                //ViewBag.Dropdown_SubCategory = new SelectList(subcategorylist, "ID", "SubCategory", "Select Sub Category");

            }
            return View();
        }

        [HttpPost]
        public ActionResult GetSubCategoryList_ByCategoryId(int Category_Id)
        {
            using (DataContext dc = new DataContext())
            {
                var subcategorylist = dc.FF_Sub_Category.Where(a => a.Category_ID == Category_Id).AsEnumerable().Select(s => new
                {
                    SubCategoryId = s.ID,
                    SubCategory = s.SubCategory
                }).ToList();

                return Json(subcategorylist, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddProductDetails(VM_Product product)//VM_Product product, HttpPostedFileBase file1 //string Category_ID, string Brand
        {
            try
            {
                //return View();
                int User_ID = Convert.ToInt32(SessionObject.userid ?? 0);

                if (User_ID == 0)
                {
                    return Json("session_expire", JsonRequestBehavior.AllowGet);
                }

                FF_Products p = new FF_Products();
                p.Category_ID = Convert.ToInt32(product.Category_ID);
                p.Sub_Category_ID = Convert.ToInt32(product.Sub_Category_ID);
                p.User_ID = User_ID;
                p.Brand = product.Brand;
                p.Product_Name = product.Product_Name;
                p.Product_Code = product.Product_Code;

                if (string.IsNullOrEmpty(product.Price))
                {
                    p.Price = "0";
                }
                else
                {
                    p.Price = product.Price;
                }

                if (string.IsNullOrEmpty(product.Quantity))
                {
                    p.Quantity = "0";
                }
                else
                {
                    p.Quantity = product.Quantity;
                }

                p.Discount = product.Discount;
                p.Description = product.Description;
                p.Image = "";
                p.Creation_Date = DateTime.UtcNow;
                //p.IsProduct_Hide = "0";

                interfaceobj.InsertModel(p);
                interfaceobj.Save();

                // BELOW CODE IS TO ADD PRODUCT VARIANT//
                if (!string.IsNullOrEmpty(product.VariantCollection))
                {

                    string[] coll = product.VariantCollection.Split(new string[] { "<|>" }, StringSplitOptions.RemoveEmptyEntries);

                    int sumofvariantquantiy = 0;

                    foreach (var item in coll)
                    {
                        FF_Product_SubTable PST = new FF_Product_SubTable();

                        string[] split2 = item.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        PST.Product_Id = p.ID;
                        PST.Product_Variant_Id = product.Product_Variant_Id;

                        string GlobalVariantText = split2[0];

                        if (GlobalVariantText.ToLower() == "colour/size")
                        {
                            PST.Product_Size = split2[1];
                            PST.Product_Colour = split2[2];
                            PST.Product_Price = split2[3];
                            PST.Product_Quantity = split2[4];

                            sumofvariantquantiy += Convert.ToInt32(split2[4]);
                        }
                        else
                        {
                            if (GlobalVariantText.ToLower() == "size")
                            {
                                PST.Product_Size = split2[1];
                            }
                            else if (GlobalVariantText.ToLower() == "colour")
                            {
                                PST.Product_Colour = split2[1];
                            }
                            else if (GlobalVariantText.ToLower() == "weight")
                            {
                                PST.Product_Weight = split2[1];
                            }

                            PST.Product_Price = split2[2];
                            PST.Product_Quantity = split2[3];

                            sumofvariantquantiy += Convert.ToInt32(split2[3]);
                        }
                        interfaceobj_Product_SubTable.InsertModel(PST);

                    }

                    interfaceobj_Product_SubTable.Save();

                    //UPDATE QUANTITY(SUM) IN PRODUCT MAIN TABLE
                    //var updateproductrecord = interfaceobj.GetModelById(p.ID);
                    //updateproductrecord.Quantity = sumofvariantquantiy.ToString();
                    //updateproductrecord.Price = null;

                    p.Quantity = sumofvariantquantiy.ToString();
                    p.Price = "";
                    interfaceobj.UpdateModel(p);
                    interfaceobj.Save();


                }
                // END//

                //return View();

                //Product Image Uploding code
                int filecount = Request.Files.Count;
                if (filecount > 0)
                {
                    //  Get all files from Request object  
                    //HttpPostedFileBase postedfile = Request.Files[0];
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase postedfile = files[i];

                        string savepath = HttpContext.Server.MapPath("~/content/Product_Image/");
                        if (System.IO.Directory.Exists(savepath))
                        {
                            //savepath += "Product_Image/";
                            //if (!System.IO.Directory.Exists(savepath))
                            //{
                            //    System.IO.Directory.CreateDirectory(savepath);
                            //}
                            int ProductID = p.ID;

                            savepath += ProductID + "/";
                            if (!System.IO.Directory.Exists(savepath))
                            {
                                System.IO.Directory.CreateDirectory(savepath);
                            }
                            string FileName = DateTime.UtcNow.Ticks.ToString();
                            int A = postedfile.FileName.LastIndexOf(".");
                            int length = postedfile.FileName.Length;
                            string extention = postedfile.FileName.Substring(A, length - A);

                            if (System.IO.File.Exists(savepath + FileName + ".jpg"))
                            {
                                System.IO.File.SetAttributes(savepath + FileName + ".jpg", System.IO.FileAttributes.Normal);
                                System.IO.File.Delete(savepath + FileName + ".jpg");
                            }

                            postedfile.SaveAs(savepath + FileName + ".jpg");

                            ////Below Code is to Save First Product Image in Product DB Table
                            if (i == 0)
                            {
                                p.Image = "../content/Product_Image/" + ProductID + "/" + FileName + ".jpg";
                                interfaceobj.UpdateModel(p);
                                interfaceobj.Save();
                            }

                            //LinqConnection dc = new LinqConnection();

                            //var UpdateImage = dc.FF_Products.FirstOrDefault(a => a.ID == ProductID);

                            //if (UpdateImage != null)
                            //{
                            //    UpdateImage.Image = ProductID + ".jpg";
                            //    dc.SubmitChanges();
                            //}

                            // return Json("done", JsonRequestBehavior.AllowGet);
                        }
                    }

                }

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }


        }


        [Authorize(Roles = "admin")]
        public ActionResult ProductList()
        {
            //using (DataContext dc = new DataContext())
            //{
            //    var catlist = dc.FF_Category.ToList();
            //    ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category");
            //    //         ViewBag.Dropdown_Category = catlist
            //    //.ToList()
            //    //.Select(x => new SelectListItem
            //    //{
            //    //    Value = x.ID.ToString(),
            //    //    Text = x.Category,
            //    //    //Selected = (x.ID == 3)
            //    //});
            //}
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Get_ProductList()
        {
            int User_ID = Convert.ToInt32(SessionObject.userid ?? 0);

            var productList = interfaceobj.GetModel().Where(a => a.User_ID == User_ID).AsEnumerable().Select(s => new
            {
                Product_ID = s.ID,
                Product_Name = s.Product_Name,
                Product_Code = s.Product_Code,
                Category = s.FF_Category.Category,
                Brand = s.Brand,
                Price = (string.IsNullOrEmpty(s.Price) ? "-" : s.Price),
                Quantity = (string.IsNullOrEmpty(s.Quantity) ? "-" : s.Quantity),
                Discount = (string.IsNullOrEmpty(s.Discount) ? "-" : s.Discount),
                Product_Is_Hide = (s.IsProduct_Hide == true ? "hide-product-strip" : "")
                //Description = s.Description

            });

            return Json(productList, JsonRequestBehavior.AllowGet);

        }


        //[Authorize(Roles = "vendor")]
        [Authorize(Roles = "admin")]
        public ActionResult GetProductRecords()
        {
            string Product_Id = Request.QueryString["Product_Id"];

            var productrecord = interfaceobj.GetModel().Where(a => a.ID == Convert.ToInt32(Product_Id)).AsEnumerable();

            //    DataContext dc = new DataContext();

            //    var catlist = dc.FF_Category;
            //    //ViewBag.id = productrecord.FirstOrDefault().Category_ID.ToString();

            //    //ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category", "4");
            //    ViewBag.Dropdown_Category = catlist
            //.ToList()
            //.Select(x => new SelectListItem
            //{
            //    Value = x.ID.ToString(),
            //    Text = x.Category,
            //    Selected = (x.ID == 4)
            //});
            //ViewBag.Dropdown_Category = new SelectList(catlist.Select(item => new SelectListItem
            //{
            //    Value = item.ID.ToString(),
            //    Text = item.Category.ToString()
            //    //Selected = (productrecord.Select(s => s.Category_ID).ToString() == item.ID.ToString() ? true : false)
            //    //Selected = "select" == item.FF_Products.FirstOrDefault().Category_ID.ToString()
            //}));

            var productrecordList = productrecord.Select(s => new
            {
                ProductId = s.ID,
                BrandName = (string.IsNullOrEmpty(s.Brand) ? "" : s.Brand),
                ProductName = s.Product_Name,
                ProductCode = s.Product_Code,
                ProductPrice = (string.IsNullOrEmpty(s.Price) ? "" : s.Price),
                ProductQuantity = (string.IsNullOrEmpty(s.Quantity) ? "-" : s.Quantity),
                ProductDiscount = (string.IsNullOrEmpty(s.Discount) ? "-" : s.Discount + " %"),
                CreationDate = s.Creation_Date.ToString("dd-MMM-yyyy"),
                Description = (string.IsNullOrEmpty(s.Description) ? "-" : s.Description),
                Category = s.FF_Category.Category,

                ImageCollection = MyHelperClass.GetProduct_Images(Convert.ToInt32(Product_Id))


            });
            return Json(productrecordList, JsonRequestBehavior.AllowGet);
            //return Json(productrecord, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "admin")]
        public ActionResult GetProductRecordsForEdit()
        {
            int Product_Id = Convert.ToInt32(Request.QueryString["Product_Id"]);

            //Product Main Table//
            var productrecord = interfaceobj.GetModel().Where(a => a.ID == Product_Id).AsEnumerable();

            DataContext dc = new DataContext();

            //Category for dropdownlist
            var catlist = dc.FF_Category;
            ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category");

            //Sub Category for dropdownlist
            var subcatlist = dc.FF_Sub_Category;
            ViewBag.Dropdown_SubCategory = new SelectList(subcatlist, "ID", "SubCategory");

            //Product Variant for dropdownlist
            var variantlist = dc.FF_Product_Variants;
            ViewBag.Dropdown_Variant = new SelectList(variantlist, "ID", "Variants_Name", "Select Variant");


            VM_Product modal = new VM_Product();

            var Product_Variant_Id = ((dc.FF_Product_SubTable.Where(a => a.Product_Id == Product_Id).Count() > 0) ? dc.FF_Product_SubTable.Where(a => a.Product_Id == Product_Id).First().Product_Variant_Id : 0);

            modal.ID = Product_Id;
            modal.Category_ID = productrecord.FirstOrDefault().Category_ID;
            modal.Sub_Category_ID = productrecord.FirstOrDefault().Sub_Category_ID;
            //modal.Product_Variant_Id = dc.FF_Product_SubTable.FirstOrDefault(a => a.Product_Id == Product_Id).Product_Variant_Id;
            modal.Product_Variant_Id = ((dc.FF_Product_SubTable.Where(a => a.Product_Id == Product_Id).Count() > 0) ? dc.FF_Product_SubTable.Where(a => a.Product_Id == Product_Id).First().Product_Variant_Id : 0);

            modal.Brand = productrecord.FirstOrDefault().Brand;
            modal.Product_Name = productrecord.FirstOrDefault().Product_Name;
            modal.Product_Code = productrecord.FirstOrDefault().Product_Code;
            modal.Price = productrecord.FirstOrDefault().Price;
            modal.Quantity = productrecord.FirstOrDefault().Quantity;
            modal.Discount = productrecord.FirstOrDefault().Discount;
            modal.Description = productrecord.FirstOrDefault().Description;
            modal.ImageCollection = MyHelperClass.GetProduct_Images(Product_Id);
            if (Product_Variant_Id != 4 && Product_Variant_Id != 0)
            {
                modal.VariantCollectionList = dc.FF_Product_SubTable.Where(f => f.Product_Id == Product_Id).Select(s => new VariantCollection
                {
                    Product_Sub_Table_ID = s.ID,
                    First_Input = (string.IsNullOrEmpty(s.Product_Size) ? (string.IsNullOrEmpty(s.Product_Colour) ? s.Product_Weight : s.Product_Colour) : s.Product_Size),
                    Second_Input = s.Product_Price,
                    Third_Input = s.Product_Quantity,
                    //Size = s.Product_Size,
                    //Colour = s.Product_Colour,
                    //Weight = s.Product_Weight,
                    //Price = s.Product_Price,
                    //Quantity = s.Product_Quantity

                }).ToList();

            }
            else if (Product_Variant_Id == 4)
            {
                modal.VariantCollectionList = dc.FF_Product_SubTable.Where(f => f.Product_Id == Product_Id).Select(s => new VariantCollection
                {
                    Product_Sub_Table_ID = s.ID,
                    First_Input = s.Product_Size,
                    Second_Input = s.Product_Colour,
                    Third_Input = s.Product_Price,
                    Fourth_Input = s.Product_Quantity
                    //Size = s.Product_Size,
                    //Colour = s.Product_Colour,
                    //Weight = s.Product_Weight,
                    //Price = s.Product_Price,
                    //Quantity = s.Product_Quantity

                }).ToList();


            }


            return View("PV_EditProduct", modal);
            //return Json(productrecord, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateProductDetails(VM_Product product)//VM_Product product, HttpPostedFileBase file1
        {
            try
            {
                int User_ID = Convert.ToInt32(SessionObject.userid ?? 0);

                if (User_ID == 0)
                {
                    return Json("session_expire", JsonRequestBehavior.AllowGet);
                }

                var UpdateRecord = interfaceobj.GetModel().FirstOrDefault(a => a.ID == product.ID);

                UpdateRecord.Category_ID = Convert.ToInt32(product.Category_ID);
                UpdateRecord.Sub_Category_ID = Convert.ToInt32(product.Sub_Category_ID);
                UpdateRecord.User_ID = User_ID;
                UpdateRecord.Brand = product.Brand;
                UpdateRecord.Product_Name = product.Product_Name;
                UpdateRecord.Product_Code = product.Product_Code;

                if (string.IsNullOrEmpty(product.Price))
                {
                    UpdateRecord.Price = "0";
                }
                else
                {
                    UpdateRecord.Price = product.Price;
                }

                if (string.IsNullOrEmpty(product.Quantity))
                {
                    UpdateRecord.Quantity = "0";
                }
                else
                {
                    UpdateRecord.Quantity = product.Quantity;
                }

                UpdateRecord.Discount = product.Discount;
                UpdateRecord.Description = product.Description;
                UpdateRecord.Image = "";
                //UpdateRecord.Creation_Date = DateTime.UtcNow;
                //UpdateRecord.IsProduct_Hide = "0";

                interfaceobj.UpdateModel(UpdateRecord);
                interfaceobj.Save();

                // BELOW CODE IS TO ADD PRODUCT VARIANT//
                if (!string.IsNullOrEmpty(product.VariantCollection))
                {
                    /////Delete all product related record from product sub table 
                    /////Then insert all product variant record
                    var DeleteProductVariantRecord = interfaceobj_Product_SubTable.GetModel().Where(x => x.Product_Id == product.ID);

                    if (DeleteProductVariantRecord != null)
                    {
                        foreach (var item in DeleteProductVariantRecord)
                        {
                            interfaceobj_Product_SubTable.DeleteModel(Convert.ToInt32(item.ID));
                            interfaceobj_Product_SubTable.Save();
                        }
                    }
                    /////End

                    string[] coll = product.VariantCollection.Split(new string[] { "<|>" }, StringSplitOptions.RemoveEmptyEntries);

                    int sumofvariantquantiy = 0;

                    foreach (var item in coll)
                    {
                        FF_Product_SubTable PST = new FF_Product_SubTable();

                        string[] split2 = item.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        PST.Product_Id = product.ID;
                        PST.Product_Variant_Id = product.Product_Variant_Id;

                        string GlobalVariantText = split2[0];

                        if (GlobalVariantText.ToLower() == "colour/size")
                        {
                            PST.Product_Size = split2[1];
                            PST.Product_Colour = split2[2];
                            PST.Product_Price = split2[3];
                            PST.Product_Quantity = split2[4];

                            sumofvariantquantiy += Convert.ToInt32(split2[4]);
                        }
                        else
                        {
                            if (GlobalVariantText.ToLower() == "size")
                            {
                                PST.Product_Size = split2[1];
                            }
                            else if (GlobalVariantText.ToLower() == "colour")
                            {
                                PST.Product_Colour = split2[1];
                            }
                            else if (GlobalVariantText.ToLower() == "weight")
                            {
                                PST.Product_Weight = split2[1];
                            }

                            PST.Product_Price = split2[2];
                            PST.Product_Quantity = split2[3];

                            sumofvariantquantiy += Convert.ToInt32(split2[3]);
                        }
                        interfaceobj_Product_SubTable.InsertModel(PST);

                    }

                    interfaceobj_Product_SubTable.Save();

                    //UPDATE QUANTITY(SUM) IN PRODUCT MAIN TABLE
                    UpdateRecord.Quantity = sumofvariantquantiy.ToString();
                    UpdateRecord.Price = "";
                    interfaceobj.UpdateModel(UpdateRecord);
                    interfaceobj.Save();


                }
                // END//

                //Product Image Uploding code
                int filecount = Request.Files.Count;
                if (filecount > 0)
                {
                    //  Get all files from Request object  
                    //HttpPostedFileBase postedfile = Request.Files[0];
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase postedfile = files[i];

                        string savepath = HttpContext.Server.MapPath("~/content/Product_Image/");
                        if (System.IO.Directory.Exists(savepath))
                        {
                            //savepath += "Product_Image/";
                            //if (!System.IO.Directory.Exists(savepath))
                            //{
                            //    System.IO.Directory.CreateDirectory(savepath);
                            //}
                            int ProductID = product.ID;

                            savepath += ProductID + "/";
                            if (!System.IO.Directory.Exists(savepath))
                            {
                                System.IO.Directory.CreateDirectory(savepath);
                            }
                            string FileName = DateTime.UtcNow.Ticks.ToString();
                            int A = postedfile.FileName.LastIndexOf(".");
                            int length = postedfile.FileName.Length;
                            string extention = postedfile.FileName.Substring(A, length - A);

                            if (System.IO.File.Exists(savepath + FileName + ".jpg"))
                            {
                                System.IO.File.SetAttributes(savepath + FileName + ".jpg", System.IO.FileAttributes.Normal);
                                System.IO.File.Delete(savepath + FileName + ".jpg");
                            }

                            postedfile.SaveAs(savepath + FileName + ".jpg");

                            //if (System.IO.File.Exists(savepath + "Image-" + i + ".jpg"))
                            //{
                            //    System.IO.File.SetAttributes(savepath + "Image-" + i + ".jpg", System.IO.FileAttributes.Normal);
                            //    System.IO.File.Delete(savepath + "Image-" + i + ".jpg");
                            //}

                            //postedfile.SaveAs(savepath + "Image-" + i + ".jpg");

                            ////Below Code is to Save First Product Image in Product DB Table
                            if (i == 0)
                            {
                                UpdateRecord.Image = "../content/Product_Image/" + ProductID + "/" + "Image-" + i + ".jpg";
                                interfaceobj.UpdateModel(UpdateRecord);
                                interfaceobj.Save();
                            }

                        }
                    }
                    return Json("done", JsonRequestBehavior.AllowGet);
                }

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return Json("error", JsonRequestBehavior.AllowGet);
            }


        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteProductSingleRecord()
        {
            string Product_Id = Request.QueryString["Product_Id"];

            var ProductRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Convert.ToInt32(Product_Id));

            if (ProductRecord != null)
            {
                // FIRST WE ARE CHECKING - IS ANY DOCUMENT UPLOADED FOR SELECTED PRODUCT
                // IF YES THEN FIRST REMOVE THAT DOCUMENTS THEN REMOVE PRODUCT
                string savepath = HttpContext.Server.MapPath("~/content/Product_Image/" + Product_Id + "/");

                if (Directory.Exists(savepath))
                {
                    Directory.Delete(savepath, true);
                }

                //DirectoryInfo dir = new DirectoryInfo(savepath);

                //foreach (FileInfo fi in dir.GetFiles())
                //{
                //    fi.Delete();
                //}


                //if (System.IO.File.Exists(savepath + Product_Id + ".jpg"))
                //{
                //    System.IO.File.SetAttributes(savepath + Product_Id + ".jpg", System.IO.FileAttributes.Normal);
                //    System.IO.File.Delete(savepath + Product_Id + ".jpg");
                //}

                interfaceobj.DeleteModel(Convert.ToInt32(Product_Id));
                //interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteProductMultipleRecord(string ProductIds)
        {
            try
            {
                List<string> collection = ProductIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var ProductRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));

                foreach (var item in ProductRecord)
                {
                    // FIRST WE ARE CHECKING - IS ANY DOCUMENT UPLOADED FOR SELECTED PRODUCT
                    // IF YES THEN FIRST REMOVE THAT DOCUMENTS THEN REMOVE PRODUCT
                    string savepath = HttpContext.Server.MapPath("~/content/Product_Image/" + item.ID + "/");

                    if (Directory.Exists(savepath))
                    {
                        Directory.Delete(savepath, true);
                    }

                    interfaceobj.DeleteModel(Convert.ToInt32(item.ID));
                    //interfaceobj.Save();

                }

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize(Roles = "vendor")]
        public ActionResult Hide_Show_ProductMultipleRecord(string ProductIds)
        {
            try
            {
                List<string> collection = ProductIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var ProductRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));

                foreach (var item in ProductRecord)
                {
                    if (item.IsProduct_Hide == true)
                    {
                        item.IsProduct_Hide = false;
                    }
                    else
                    {
                        item.IsProduct_Hide = true;
                    }

                    interfaceobj.Save();

                }

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult DeleteProduct_Images(int productid, string imagename)
        {
            if (System.IO.Directory.Exists(HttpContext.Server.MapPath("/content/Product_Image/" + productid + "/")))
            {
                System.IO.File.Delete(HttpContext.Server.MapPath("/content/Product_Image/" + productid + "/" + imagename));
                return Json("done", JsonRequestBehavior.AllowGet);
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteProductVariantRecord(int Product_ID, int Record_Id)
        {
            try
            {
                //int Record_Id = Convert.ToInt32(Request.QueryString["Record_Id"]);

                var ProductVariantRecord = interfaceobj_Product_SubTable.GetModel().FirstOrDefault(s => s.ID == Record_Id);

                if (ProductVariantRecord != null)
                {

                    interfaceobj_Product_SubTable.DeleteModel(Record_Id);
                    interfaceobj_Product_SubTable.Save();

                    ////Below code is to update quantity record from main product table
                    var sumofquantity = interfaceobj_Product_SubTable.GetModel().Where(w => w.Product_Id == Product_ID);

                    int sum = sumofquantity.Sum(a => Convert.ToInt32(a.Product_Quantity));

                    var ProductRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Product_ID);

                    ProductRecord.Quantity = sum.ToString();

                    interfaceobj.UpdateModel(ProductRecord);
                    interfaceobj.Save();
                    ////End

                    return Json(new { Action = "done", msg = "Record deleted successfully." });
                }

                return Json(new { Action = "error", msg = "Can not delete record this time. Please try again later." });

            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Can not delete record this time. Please try again later." });
            }

        }


    }
}
