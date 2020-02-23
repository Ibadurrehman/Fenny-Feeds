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
    public class ServiceAreaController : Controller
    {
        private _IAllRepository<FF_Service_Area> interfaceobj;

        public ServiceAreaController()
        {
            this.interfaceobj = new AllRepository<FF_Service_Area>();
        }


        //
        // GET: /ServiceArea/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddServiceArea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddServiceAreaDetails()
        {
            try
            {
                string AreaName = Request.QueryString["AreaName"];
                string AreaPinCode = Request.QueryString["AreaPinCode"];

                FF_Service_Area sa = new FF_Service_Area();
                sa.Name = AreaName;
                sa.PinCode = Convert.ToInt32(AreaPinCode);

                interfaceobj.InsertModel(sa);
                interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }



        public ActionResult ServiceAreaList()
        {
            return View();
        }


        public ActionResult Get_ServiceAreaList()
        {
            var serviceAreaList = interfaceobj.GetModel().AsEnumerable().Select(s => new
            {
                ServiceArea_ID = s.Id,
                AreaName = s.Name,
                AreaPinCode = s.PinCode

            });

            return Json(serviceAreaList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteServiceAreaSingleRecord()
        {
            string ServiceArea_Id = Request.QueryString["ServiceArea_Id"];

            var ServiceAreaRecord = interfaceobj.GetModel().FirstOrDefault(s => s.Id == Convert.ToInt32(ServiceArea_Id));

            if (ServiceAreaRecord != null)
            {
                interfaceobj.DeleteModel(Convert.ToInt32(ServiceArea_Id));
                //interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteServiceAreaMultipleRecord(string ServiceAreaIds)
        {
            try
            {
                List<string> collection = ServiceAreaIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var ServiceAreaRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.Id.ToString()));

                foreach (var item in ServiceAreaRecord)
                {
                    interfaceobj.DeleteModel(Convert.ToInt32(item.Id));
                    //interfaceobj.Save();

                }

                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }



    }
}
