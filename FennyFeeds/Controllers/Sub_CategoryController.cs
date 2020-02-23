using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [SessionTimeout]
    public class Sub_CategoryController : Controller
    {
         private _IAllRepository<FF_Sub_Category> interfaceobj;

         public Sub_CategoryController()
        {
            this.interfaceobj = new AllRepository<FF_Sub_Category>();
        }

        //
        // GET: /Sub_Category/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddSubCategory()
        {
            using (DataContext dc = new DataContext())
            {
                var catlist = dc.FF_Category.ToList();
                ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category", "Select Category");

            }
            return View();
        }

        [HttpPost]
        public ActionResult AddSubCategoryDetails(int Category_Id, string SubCategory, bool IsActive)
        {
            try
            {
                //string Category = Request.QueryString["Category"];

                FF_Sub_Category sc = new FF_Sub_Category();
                sc.Category_ID = Category_Id;
                sc.SubCategory = SubCategory;
                sc.IsActive = IsActive;

                interfaceobj.InsertModel(sc);
                interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }


        //public ActionResult Get_CategoryList()
        //{

        //    var productList = interfaceobj.GetModel().AsEnumerable().Select(s => new
        //    {
        //        Product_ID = s.ID,
        //        Product_Name = s.Product_Name,
        //        Product_Code = s.Product_Code,
        //        Category = s.FF_Category.Category,
        //        Brand = s.Brand,
        //        Price = s.Price,
        //        Quantity = s.Quantity,
        //        Discount = s.Discount
        //        //Description = s.Description

        //    });

        //    return Json(productList, JsonRequestBehavior.AllowGet);

        //}

    }
}
