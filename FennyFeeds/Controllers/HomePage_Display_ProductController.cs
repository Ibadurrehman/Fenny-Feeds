using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using FennyFeeds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [SessionTimeout]
    public class HomePage_Display_ProductController : Controller
    {
        //
        // GET: /HomePage_Display_Product/
        private _IAllRepository<FF_HomePage_Display_Product> interfaceobj;

        public HomePage_Display_ProductController()
        {
            this.interfaceobj = new AllRepository<FF_HomePage_Display_Product>();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_Category_ToDisplayProduct()
        {
            using (DataContext dc = new DataContext())
            {
                var catlist = dc.FF_Category.ToList();
                ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category", "Select Category");
            }
            return View();
        }


        [HttpPost]
        public ActionResult AddProduct_Display_Details(VM_HomePage_Display_Product home)
        {
            try
            {
                int AdminId = Convert.ToInt32(SessionObject.superadminid ?? 0);

                if (AdminId == 0)
                {
                    //return Json(new { Action = "error", msg = "Session expired ! Please relogin to continue." });
                }

                var ChechProductAlreadyDiplay = interfaceobj.GetModel().Where(a =>a.Category_ID == home.Category_ID);

                if (ChechProductAlreadyDiplay.Count() > 0)
                {
                    return Json(new { Action = "error", msg = "This Category already displayed." });
                }

                FF_HomePage_Display_Product h = new FF_HomePage_Display_Product();
                h.Category_ID = Convert.ToInt32(home.Category_ID);
                h.Title = home.Title;

                interfaceobj.InsertModel(h);
                interfaceobj.Save();

                return Json(new { Action = "done", msg = "Details added successfully." });

            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Cannot update details this time please try again later." });
            }


        }

        public ActionResult DisplayProductList()
        {
            return View();
        }

        public ActionResult Get_Display_Product_List()
        {
            var displayproductList = interfaceobj.GetModel().AsEnumerable().Select(s => new
                        {
                            Record_ID = s.ID,
                            Category = s.FF_Category.Category,
                            Title = s.Title
                        });

            return Json(displayproductList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetDisplayProductRecords()
        {
            string Record_ID = Request.QueryString["Record_ID"];

            var displayproductrecord = interfaceobj.GetModel().Where(a => a.ID == Convert.ToInt32(Record_ID)).AsEnumerable();

            DataContext dc = new DataContext();

            var catlist = dc.FF_Category.ToList();
            ViewBag.Dropdown_Category = new SelectList(catlist, "ID", "Category", "Select Category");

            VM_HomePage_Display_Product model = new VM_HomePage_Display_Product();

            model.ID = displayproductrecord.First().ID;
            model.Category_ID = displayproductrecord.First().Category_ID;
            model.Title = displayproductrecord.First().Title;

            return PartialView("PV_EditProductDisplay", model);

        }


        [HttpPost]
        public ActionResult EditProduct_Display_Details(int Record_ID, int Category_ID, string Title)//VM_HomePage_Display_Product updatedetails
        {
            try
            {
                int AdminId = Convert.ToInt32(SessionObject.superadminid ?? 0);

                if (AdminId == 0)
                {
                    //return Json(new { Action = "error", msg = "Session expired ! Please relogin to continue." });
                }

                var ChechProductAlreadyDiplay = interfaceobj.GetModel().Where(a => !(a.ID == Record_ID) && a.Category_ID == Category_ID);

                if (ChechProductAlreadyDiplay.Count() > 0)
                {
                    return Json(new { Action = "error", msg = "This Category already displayed." });
                }

                var UpdateRecord = interfaceobj.GetModel().FirstOrDefault(a => a.ID == Record_ID);

                if (UpdateRecord != null)
                {
                    //FF_HomePage_Display_Product h = new FF_HomePage_Display_Product();
                    UpdateRecord.Category_ID = Convert.ToInt32(Category_ID);
                    UpdateRecord.Title = Title;

                    interfaceobj.UpdateModel(UpdateRecord);
                    interfaceobj.Save();
                }
                return Json(new { Action = "done", msg = "Details updated successfully." });

            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Cannot update details this time please try again later." });
            }


        }


        public ActionResult DeleteDisplayProductSingleRecord()
        {
            try
            {
                int Record_ID = Convert.ToInt32(Request.QueryString["Record_ID"]);

                var DisplayProductRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Record_ID);

                if (DisplayProductRecord != null)
                {
                    interfaceobj.DeleteModel(Convert.ToInt32(Record_ID));
                    interfaceobj.Save();

                    return Json(new { Action = "done", msg = "Record deleted successfully." });
                }

                return Json(new { Action = "error", msg = "Can not delete record this time. Please try again later." });

            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Can not delete record this time. Please try again later." });
            }


        }

        public ActionResult DeleteDisplayProductMultipleRecord(string RecordIds)
        {
            try
            {
                List<string> collection = RecordIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var DisplayProductRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));
                if (DisplayProductRecord != null)
                {

                    foreach (var item in DisplayProductRecord)
                    {
                        interfaceobj.DeleteModel(Convert.ToInt32(item.ID));
                        //interfaceobj.Save();
                    }
                    return Json(new { Action = "done", msg = "Records deleted successfully." });
                }
                return Json(new { Action = "error", msg = "Can not delete records this time. Please try again later." });
            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Can not delete records this time. Please try again later." });
            }

        }

    }
}
