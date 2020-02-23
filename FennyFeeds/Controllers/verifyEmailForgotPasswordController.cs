using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    public class verifyEmailForgotPasswordController : Controller
    {
        public string VerifyID = "";

        private _IAllRepository<FF_Registration> interfaceobj;

        public verifyEmailForgotPasswordController()
        {
            this.interfaceobj = new AllRepository<FF_Registration>();
        }
        //
        // GET: /verifyEmailForgotPassword/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult verifyEmailForgotPassword()
        {
            try
            {
                VerifyID = Request.QueryString["verifyid"]; //"36CDAED5EF34F8CAB8D788DAA";//
                ViewBag.VerifyID = VerifyID;
            }
            catch (Exception)
            { }

            try
            {
                var data = interfaceobj.GetModel().FirstOrDefault(s => s.Recovery_Link== VerifyID);
                if (data == null)
                {
                    ViewBag.unsuccessDiv = true;
                    ViewBag.successDiv = false;

                }
                else
                {
                 
                    ViewBag.unsuccessDiv = false;
                    ViewBag.successDiv = true;
                }

            }
            catch (Exception)
            {
                ViewBag.unsuccessDiv = false;
                ViewBag.successDiv = true;
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword()
        {
            string verifyid = "";
            string Password = "";
            try
            {
                verifyid = Request.QueryString["verifyid"];
            }
            catch (Exception)
            {

            }
            try
            {
                Password = Request.QueryString["Password"];
            }
            catch (Exception)
            {

            }
            try
            {
                var pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                var getRecord = interfaceobj.GetModel().FirstOrDefault(f => f.Recovery_Link == verifyid);
                //var getRecord = (from gr in dc.FF_Registrations
                //                 where gr.Recovery_Link == verifyid
                //                 select gr).FirstOrDefault();

                if (getRecord != null)
                {
                    getRecord.Password = pwd;
                    getRecord.Recovery_Link = null;
                    interfaceobj.Save();
                    return Json("done", JsonRequestBehavior.AllowGet);
                }
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            return View();
        }


    }
}
