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
    [AllowAnonymous]
    public class MasterController : Controller
    {
        private _IAllRepository<FF_Subscription> interfaceobj;
        private _IAllRepository<FF_Wish_List> interfaceobj_For_Wishlist;

        public MasterController()
        {
            this.interfaceobj = new AllRepository<FF_Subscription>();
            this.interfaceobj_For_Wishlist = new AllRepository<FF_Wish_List>();
        }
        //
        // GET: /Master/

        //[HttpPost]
        //public ActionResult Upload_ProductImage()
        //{
        //    //int filecount = Request.Files.Count;
        //    //if (filecount > 0)
        //    //{
        //    //    HttpPostedFileBase postedfile = Request.Files[0];

        //    //    string savepath = HttpContext.Server.MapPath("~/Product_Image/");

        //    //    if (System.IO.Directory.Exists(savepath))
        //    //    {
        //    //        //savepath += "Product_Image/";
        //    //        //if (!System.IO.Directory.Exists(savepath))
        //    //        //{
        //    //        //    System.IO.Directory.CreateDirectory(savepath);
        //    //        //}
        //    //        int A = postedfile.FileName.LastIndexOf(".");
        //    //        int length = postedfile.FileName.Length;
        //    //        string extention = postedfile.FileName.Substring(A, length - A);

        //    //        if (System.IO.File.Exists(savepath + ProductID + ".jpg"))
        //    //        {
        //    //            System.IO.File.SetAttributes(savepath + ProductID + ".jpg", System.IO.FileAttributes.Normal);
        //    //            System.IO.File.Delete(savepath + ProductID + ".jpg");
        //    //        }

        //    //        postedfile.SaveAs(savepath + ProductID + ".jpg");

        //    //        LinqConnection dc = new LinqConnection();

        //    //        var UpdateImage = dc.FF_Products.FirstOrDefault(a => a.ID == ProductID);

        //    //        if (UpdateImage != null)
        //    //        {
        //    //            UpdateImage.Image = ProductID + ".jpg";
        //    //            dc.SubmitChanges();
        //    //        }

        //    //        context.Response.Write("done");
        //    //    }
        //    //}

        //    return View();
        //}


        [HttpPost]
        public ActionResult Suscribe(string Email_Id)
        {
            try
            {
                var CheckEmailExist = interfaceobj.GetModel().FirstOrDefault(a => a.Email == Email_Id);
                if (CheckEmailExist != null)
                {
                    return Json("emailexist", JsonRequestBehavior.AllowGet);
                }

                FF_Subscription sub = new FF_Subscription();

                sub.Email = Email_Id;
                sub.Subscription_Date = DateTime.UtcNow;

                interfaceobj.InsertModel(sub);
                //interfaceobj.Save();

                //Subscription Mail to User//
                Utility_FF.SendMail(new string[] { Email_Id }, new Utility_FF.EmailTemplate(EmailTemplate.SubscriptionMailToUser), new string[] { Email_Id }, "Subscription");

                //Subscription Mail to Admin//
                Utility_FF.SendMail(new string[] { "mayank.gupta262@gmail.com" }, new Utility_FF.EmailTemplate(EmailTemplate.SubscriptionMailToAdmin), new string[] { Email_Id }, "Subscription");

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("erroe", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ProductQuickView()
        {
            int Product_ID = Convert.ToInt32(Request.QueryString["Product_ID"]);

            using (DataContext dc = new DataContext())
            {
                var displayproductrecord = dc.FF_Products.Where(a => a.ID == Product_ID).AsEnumerable();

                var ProductAllImages = MyHelperClass.GetProduct_Images(Product_ID);
                    
                VM_Product model = new VM_Product();

                model.ID = displayproductrecord.First().ID;
                model.Product_Name = displayproductrecord.First().Product_Name;
                model.Product_Code = displayproductrecord.First().Product_Code;
                model.Price = displayproductrecord.First().Price;
                model.Discount = displayproductrecord.First().Discount;
                model.Quantity = displayproductrecord.First().Quantity;
                model.Description = displayproductrecord.First().Description;
                model.ImageCollection = ProductAllImages;
                
                return PartialView("_ProductQuickView", model);//F:\MVC-New\FennyFeeds\FennyFeeds\Views\Shared\_ProductQuickView.cshtml

            }

        }

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult Get_ProductDetails()
        {
            int Product_ID = Convert.ToInt32(Request.QueryString["Product_ID"]);

            using (DataContext dc = new DataContext())
            {
                //var displayproductrecord = dc.FF_Products.Where(a => a.ID == Product_ID).AsEnumerable();

                var ProductAllImages = MyHelperClass.GetProduct_Images(Product_ID);

                var displayproductrecord = dc.FF_Products.Where(a => a.ID == Product_ID).AsEnumerable().Select(s => new
                {
                    Product_ID = s.ID,
                    Product_Name = s.Product_Name,
                    Product_Code = s.Product_Code,
                    Price = s.Price,
                    Discount = s.Discount,
                    Quantity = s.Quantity,
                    Description = s.Description,
                    ImageCollection = ProductAllImages
                    ////ProductOtherDetails = s.FF_Product_SubTable.Select(b => new { 
                    ////Size = b.Product_Size
                    ////})


                });

                return Json(displayproductrecord,JsonRequestBehavior.AllowGet);

                ////VM_Product model = new VM_Product();

                ////model.ID = displayproductrecord.First().ID;
                ////model.Product_Name = displayproductrecord.First().Product_Name;
                ////model.Product_Code = displayproductrecord.First().Product_Code;
                ////model.Price = Convert.ToDecimal(displayproductrecord.First().Price);
                ////model.Discount = displayproductrecord.First().Discount;
                ////model.Quantity = displayproductrecord.First().Quantity;
                ////model.Description = displayproductrecord.First().Description;
                ////model.ImageCollection = ProductAllImages;

                ////return PartialView("_ProductQuickView", model);//F:\MVC-New\FennyFeeds\FennyFeeds\Views\Shared\_ProductQuickView.cshtml

            }

        }



        [HttpPost]
        public ActionResult AddToWishList()
        {
            try
            {
                int Product_ID = Convert.ToInt32(Request.QueryString["Product_ID"]);

                int UserID = Convert.ToInt32(SessionObject.userid ?? 0);
          
                if (UserID == 0)
                {
                    return RedirectToAction("../Home/Home");
                    //return Json("session_expire",JsonRequestBehavior.AllowGet);
                    //return Json(new { Action = "notlogin", msg = "You must login or create an account to save this item to your wish list!" });
                    //return "notlogin";
                }
                else
                {
                    FF_Wish_List wl = new FF_Wish_List();

                    wl.User_ID = UserID;
                    wl.Product_ID = Product_ID;

                    interfaceobj_For_Wishlist.InsertModel(wl);
                    interfaceobj.Save();

                    return Json(new { Action = "done", msg = "You have added this item to your wish list!" });
                    
                }

            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Unable to add this product to your wish list!" });
            }

        }

        //public ActionResult CheckLoginOrNotForWishList()
        //{
        //    try
        //    {
        //        int UserID = Convert.ToInt32(SessionObject.userid ?? 0);
          
        //        if (UserID == 0)
        //        {
        //            var data=false;
        //            return PartialView("_MasterPartialView", data);
        //            //return Json(new { Action = "notlogin", msg = "You must login or create an account to see your wish list!" });
        //        }
        //        else
        //        {
        //            return Json(new { Action = "done", msg = "../WishList/WishList" });
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { Action = "notlogin", msg = "You must login or create an account to see your wish list!" });
        //    }

        //}


    }
}
