using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using FennyFeeds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FennyFeeds.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //
        // GET: /Acount/
        private _IAllRepository<FF_Registration> interfaceobj;
        private _IAllRepository<FF_User_Role> interfaceobj_forUseRrole;

        public AccountController()
        {
            this.interfaceobj = new AllRepository<FF_Registration>();
            this.interfaceobj_forUseRrole = new AllRepository<FF_User_Role>();
        }
        //
        // GET: /Signup/

        public ActionResult Signup()
        {

            if (Request.Cookies["UserName1"] != null && Request.Cookies["Password1"] != null)
            {
                try
                {
                    ViewBag.cookieUsername = System.Text.Encoding.UTF8.GetString(System.Web.Security.MachineKey.Decode(Request.Cookies["UserName1"].Value.ToString(), System.Web.Security.MachineKeyProtection.All));
                    ViewBag.cookieUserPwd = System.Text.Encoding.UTF8.GetString(System.Web.Security.MachineKey.Decode(Request.Cookies["Password1"].Value.ToString(), System.Web.Security.MachineKeyProtection.All));
                }
                catch { }
            }


            try
            {
                if (Session[SessionNames.USERID.ToString()] != null)
                {
                    string actualqry = Request.QueryString["redirecturls"].ToString();
                    Response.Redirect(actualqry);
                }
                else
                {
                    string actualqry = Request.QueryString["redirecturls"].ToString();
                    ViewBag.myurlsname = actualqry;
                }
            }
            catch { }

            //return Content("");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(VM_Signup signup)
        {
            try
            {
                var CheckEmailExist = interfaceobj.GetModel().FirstOrDefault(a => a.Email_ID == signup.Email_ID);
                if (CheckEmailExist != null)
                {
                    //    [{\"Action\":\"error\",\"msg\":\"You have entered wrong email id password combination.\"}]
                    return Json("emailexist", JsonRequestBehavior.AllowGet);
                }

                string password = signup.Password;
                string EncPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                FF_Registration s = new FF_Registration();
                s.FirstName = signup.FirstName;
                s.Email_ID = signup.Email_ID;
                s.Mobile = signup.Mobile;
                s.Password = EncPassword;
                s.Creation_Date = DateTime.UtcNow;
                interfaceobj.InsertModel(s);
                interfaceobj.Save();

                FF_User_Role ur = new FF_User_Role();

                ur.User_ID = s.ID;
                ur.Role = "user";
                interfaceobj_forUseRrole.InsertModel(ur);
                interfaceobj_forUseRrole.Save();

                return Json("done", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult User_Login()//VM_Signin Login
        {

            string Emailid = "";
            try
            {
                Emailid = Request.QueryString["Email_ID"];
            }
            catch (Exception)
            { }
            string Userpassword = "";
            try
            {
                Userpassword = Request.QueryString["Password"];
            }
            catch (Exception)
            { }
            bool cbremeber = true;
            try
            {
                cbremeber = Convert.ToBoolean(Request.QueryString["cbremeber"]);
            }
            catch (Exception)
            { }
            string myurlsname = "";
            try
            {
                myurlsname = Request.QueryString["myurlsname"].ToString();
            }
            catch (Exception)
            { }
            //var Userpassword = Request.QueryString["Password"];
            //var Emailid = Request.QueryString["Email_ID"];
            //var cbremeber = Request.QueryString["cbremeber"];

            try
            {
                FF_Registration matchRecord = interfaceobj.GetModel().FirstOrDefault(u => u.Email_ID.ToLower().Equals(Emailid.ToLower()));

                if (!Userpassword.Equals(""))
                {
                    string EncPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Userpassword, "MD5");
                    matchRecord = interfaceobj.GetModel().FirstOrDefault(u => u.Email_ID.ToLower().Equals(Emailid.ToLower()) && u.Password.Equals(EncPassword));
                }

                if (matchRecord == null)
                {
                    //context.Response.Write("[{\"Action\":\"error\",\"msg\":\"You have entered wrong email id password combination.\"}]");
                    //return Content("error");
                    //return Json("error", JsonRequestBehavior.AllowGet);

                    return Json(new { Action = "error", msg = "You have entered wrong email id password combination." });

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(matchRecord.Email_ID, false);

                    var isadmin = matchRecord.FF_User_Role.FirstOrDefault(a => a.Role.ToLower().Equals("user"));
                    string MoveTo = "";
                    if (isadmin != null)
                    {
                        MoveTo = "../Home/Home";
                    }
                    else
                    {
                        MoveTo = "../Dashboard/Dashboard";
                    }

                    Session[SessionNames.USERID.ToString()] = matchRecord.ID;
                    Session[SessionNames.USERNAME.ToString()] = ((matchRecord.FirstName ?? "") + " " + (matchRecord.LastName ?? "")).Trim();
                    Session[SessionNames.USERSCREENNAME.ToString()] = (matchRecord.FirstName ?? "");
                    Session[SessionNames.USEREMAIL.ToString()] = matchRecord.Email_ID;
                    Session[SessionNames.USERROLE.ToString()] = matchRecord.FF_User_Role.First().Role;
                    //Session[SessionNames.USERTIMEZONE.ToString()] = SystemTimeZone;


                    if (cbremeber)
                    {
                        Response.Cookies["UserName1"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password1"].Expires = DateTime.Now.AddDays(30);

                    }
                    else
                    {
                        Response.Cookies["UserName1"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password1"].Expires = DateTime.Now.AddDays(-1);

                    }

                    Response.Cookies["UserName1"].Value = System.Web.Security.MachineKey.Encode(System.Text.Encoding.UTF8.GetBytes(Emailid.Trim()), System.Web.Security.MachineKeyProtection.All);
                    Response.Cookies["Password1"].Value = System.Web.Security.MachineKey.Encode(System.Text.Encoding.UTF8.GetBytes(Userpassword.Trim()), System.Web.Security.MachineKeyProtection.All);

                    //try
                    //{
                    //    FF_Account_Activity AccActivity = new FF_Account_Activity();
                    //    AccActivity.User_Id = matchRecord.ID;
                    //    AccActivity.Browser = (BrowserName ?? "");
                    //    AccActivity.IP_Address = (VisitorIpAddress ?? "");
                    //    AccActivity.Access_Date = DateTime.UtcNow;
                    //    dc.FF_Account_Activities.InsertOnSubmit(AccActivity);
                    //    dc.SubmitChanges();
                    //}
                    //catch (Exception)
                    //{ }
                    //if (MoveTo.Equals(""))
                    //{
                    //    MoveTo = "../Home/Home";
                    //    //return Json("", JsonRequestBehavior.AllowGet);
                    //}

                    ////Move To
                    //if (!string.IsNullOrEmpty(myurlsname))
                    //{ MoveTo = "Home?openuserpopup"; }

                    //Response.Write("[{\"Action\":\"move\",\"msg\":\"" + MoveTo + "\"}]");
                    return Json(new { Action = "move", msg = MoveTo });
                }
            }
            catch (Exception)
            {
                return Json(new { Action = "error", msg = "Unable to login this time. Please try again later." });
            }

        }

        [HttpPost]
        public ActionResult ForgetPassword()
        {
            try
            {
                string Email = Request.QueryString["Email"];

                var CheckEmail = interfaceobj.GetModel().FirstOrDefault(f => f.Email_ID.ToLower().Trim().Equals(Email.ToLower().Trim()));

                //var CheckEmail = (from ce in dc.FF_Registrations
                //              where ce.Email_ID.ToLower().Trim().Equals(Email.ToLower().Trim())
                //              select ce).FirstOrDefault();

                if (CheckEmail == null)
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else
                {

                    string ActivationCode = DateTime.Now.Ticks.ToString();
                    ActivationCode = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(ActivationCode, "MD5");
                    ActivationCode = ActivationCode.Length > 25 ? ActivationCode.Substring(0, 25) : ActivationCode;

                    CheckEmail.Recovery_Link = ActivationCode;
                    interfaceobj.Save();
                    //dc.SubmitChanges();

                    //Utility_FF.SendMail(new string[] { CheckEmail.Email_ID }, new Utility_FF.EmailTemplate(EmailTemplate.EmailVerification_ForgotPassword), new string[] { CheckEmail.FirstName, ActivationCode, CheckEmail.Email_ID }, "Confirm your password");

                    return Json("done", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("../Home/Home");
            //return View("../Home/Home");  
        }




    }
}
