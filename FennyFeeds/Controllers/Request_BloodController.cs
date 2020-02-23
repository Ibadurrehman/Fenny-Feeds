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
    [AllowAnonymous]
    public class Request_BloodController : Controller
    {
        //
        // GET: /Request_Blood/
         private _IAllRepository<FF_Request_Blood> interfaceobj;

         public Request_BloodController()
        {
            this.interfaceobj = new AllRepository<FF_Request_Blood>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestBlood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestBlood(VM_Request_Blood request)
        {
            try
            {

                //var CheckEmailExist = interfaceobj.GetModel().FirstOrDefault(a => a.Email_ID == request.Email_ID);
                //if (CheckEmailExist != null)
                //{
                //    //    [{\"Action\":\"error\",\"msg\":\"You have entered wrong email id password combination.\"}]
                //    return Json("emailexist", JsonRequestBehavior.AllowGet);
                //}

                FF_Request_Blood rb = new FF_Request_Blood();
                rb.UserName = request.UserName;
                rb.Email_ID = request.Email_ID;
                rb.Mobile = request.Mobile;
                rb.Address = request.Address;
                rb.PinCode = request.PinCode;
                rb.City = request.City;
                rb.State = request.State;
                rb.Pet_Name = request.Pet_Name;
                rb.Pet_Breed = request.Pet_Breed;
                rb.Request_Date = DateTime.UtcNow;
               
                interfaceobj.InsertModel(rb);
                interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }



        public ActionResult BloodRequestList()
        {
            return View();
        }


        public ActionResult Get_BloodRequesterList()
        {

            var requestList = interfaceobj.GetModel().AsEnumerable().Select(s => new
            {
                Request_ID = s.ID,
                Request_Name = s.UserName,
                Request_Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = s.Address,
                City = s.City,
                Pet_Name = s.Pet_Name,
                Pet_Breed = s.Pet_Breed
            });

            return Json(requestList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetBloodRequester_Records()
        {
            string Requester_Id = Request.QueryString["Requester_Id"];

            var requesterrecord = interfaceobj.GetModel().Where(a => a.ID == Convert.ToInt32(Requester_Id)).AsEnumerable();

            var requesterrecordList = requesterrecord.Select(s => new
            {
                Requester_ID = s.ID,
                Requester_Name = s.UserName,
                Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = s.Address,
                City = s.City,
                State = s.State,
                Request_Date = (s.Request_Date.HasValue ? s.Request_Date.Value.ToString("dd-MMM-yyyy") : "-"),
                PetName = s.Pet_Name,
                PetBreed = s.Pet_Breed
               
            });
            return Json(requesterrecordList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteRequesterSingleRecord()
        {
            string Requester_Id = Request.QueryString["Requester_Id"];

            var RequesterRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Convert.ToInt32(Requester_Id));

            if (RequesterRecord != null)
            {
                interfaceobj.DeleteModel(Convert.ToInt32(Requester_Id));
                //interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteBloodRequesterMultipleRecord(string RequesterIds)
        {
            try
            {
                List<string> collection = RequesterIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var RequesterRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));

                foreach (var item in RequesterRecord)
                {
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



    }
}
