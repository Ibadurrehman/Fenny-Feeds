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
    public class CategoryController : Controller
    {
        private _IAllRepository<FF_Category> interfaceobj;
        
        public CategoryController()
        {
            this.interfaceobj = new AllRepository<FF_Category>();
        }


        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategoryDetails(string Category, bool IsActive)
        {
            try
            {
                //string Category = Request.QueryString["Category"];

                FF_Category c = new FF_Category();
                c.Category = Category;
                c.IsActive = IsActive;

                interfaceobj.InsertModel(c);
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
