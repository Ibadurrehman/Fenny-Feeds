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
    public class User_RegistrationController : Controller
    {
        private _IAllRepository<FF_Registration> interfaceobj;
        private _IAllRepository<FF_User_Role> interfaceobj_userrole;

        public User_RegistrationController()
        {
            this.interfaceobj = new AllRepository<FF_Registration>();
            this.interfaceobj_userrole = new AllRepository<FF_User_Role>();
        }
        //
        // GET: /User_Registration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult Get_UserList()
        {

            var userList = interfaceobj.GetModel().AsEnumerable().Select(s => new
            {
                User_ID = s.ID,
                User_Name = s.FirstName,
                User_Role = string.Join(", ", s.FF_User_Role.Select(a => a.Role.ToUpper())),
                Email = s.Email_ID,
                Mobile = s.Mobile
            });

            return Json(userList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetUser_Records()
        {
            string User_Id = Request.QueryString["User_Id"];

            var userrecord = interfaceobj.GetModel().Where(a => a.ID == Convert.ToInt32(User_Id)).AsEnumerable();

            var userrecordList = userrecord.Select(s => new
            {
                User_Id = s.ID,
                UserName = s.FirstName,
                Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = (string.IsNullOrEmpty(s.Address) ? "-" : s.Address),
                City = (string.IsNullOrEmpty(s.City) ? "-" : s.City),
                State = (string.IsNullOrEmpty(s.State) ? "-" : s.State),
                Creation_Date = (s.Creation_Date.HasValue ? s.Creation_Date.Value.ToString("dd-MMM-yyyy") : "-")

            });
            return Json(userrecordList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteUserSingleRecord()
        {
            string User_Id = Request.QueryString["User_Id"];

            var UserRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Convert.ToInt32(User_Id));

            if (UserRecord != null)
            {
                interfaceobj.DeleteModel(Convert.ToInt32(User_Id));
                //interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteUserMultipleRecord(string UserIds)
        {
            try
            {
                List<string> collection = UserIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var UserRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));

                foreach (var item in UserRecord)
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



        public ActionResult AddUserRoleMultipleRecord(string UserIds, string UserRole)
        {
            try
            {
                List<string> collection = UserIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var item in collection)
                {
                    var UserRoleRecord = interfaceobj_userrole.GetModel().Where(s => s.User_ID == Convert.ToInt32(item) && s.Role.Equals(UserRole));

                    if (UserRoleRecord.Count() == 0)
                    {
                        FF_User_Role ur = new FF_User_Role();

                        ur.User_ID = Convert.ToInt32(item);
                        ur.Role = UserRole;

                        interfaceobj_userrole.InsertModel(ur);
                        interfaceobj_userrole.Save();
                    }


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
