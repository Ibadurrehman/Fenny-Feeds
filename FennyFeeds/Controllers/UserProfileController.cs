using FennyFeeds.Models.DAL;
using FennyFeeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FennyFeeds.HelperClasses;
using FennyFeeds.ViewModels;

namespace FennyFeeds.Controllers
{
    public class UserProfileController : Controller
    {
        private _IAllRepository<FF_Registration> interfaceobj;

        public UserProfileController()
        {
            this.interfaceobj = new AllRepository<FF_Registration>();
        }

        //
        // GET: /UserProfile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult GetUserProfile()
        {
            int UserID = Convert.ToInt32(SessionObject.userid ?? 0);

            var getuserdetails = interfaceobj.GetModel().Where(a => a.ID == UserID).AsEnumerable().Select(s => new
            {
                UserID = s.ID,
                FirstName = s.FirstName,
                LastName = (string.IsNullOrEmpty(s.LastName) ? "" : s.LastName),
                Email_ID = s.Email_ID,
                Mobile = (string.IsNullOrEmpty(s.Mobile) ? "" : s.Mobile),
                PinCode = (string.IsNullOrEmpty(s.PinCode) ? "" : s.PinCode),
                Address = (string.IsNullOrEmpty(s.Address) ? "" : s.Address)
            });

            return Json(getuserdetails, JsonRequestBehavior.AllowGet);


            //int UserID = Convert.ToInt32(SessionObject.userid ?? 0);

            //var getuserdetails = interfaceobj.GetModel().FirstOrDefault(a => a.ID == UserID);

            //FF_Registration model = new FF_Registration();

            //model.FirstName = getuserdetails.FirstName;
            //model.LastName = (string.IsNullOrEmpty(getuserdetails.LastName) ? "" : getuserdetails.LastName);
            //model.Email_ID = getuserdetails.Email_ID;
            //model.Mobile = (string.IsNullOrEmpty(getuserdetails.Mobile) ? "" : getuserdetails.Mobile);
            //model.PinCode = (string.IsNullOrEmpty(getuserdetails.PinCode) ? "" : getuserdetails.PinCode);
            //model.Address = (string.IsNullOrEmpty(getuserdetails.Address) ? "" : getuserdetails.Address);

            //return View("Profile", model);
        }

    }
}
