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
    public class User_RoleController : Controller
    {
        private _IAllRepository<FF_User_Role> interfaceobj;

        public User_RoleController()
        {
            this.interfaceobj = new AllRepository<FF_User_Role>();
        }

        //
        // GET: /User_Role/

        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult UserRoleList()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult Get_UserRoleList()
        {
            var roleList = interfaceobj.GetModel().AsEnumerable().Select(s => new
            {
                Record_ID = s.ID,
                UserName = s.FF_Registration.FirstName,
                RoleName = s.Role
            });

            return Json(roleList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteUserRoleSingleRecord()
        {
            try
            {
                int Record_ID = Convert.ToInt32(Request.QueryString["Record_ID"]);

                var UserRoleRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Record_ID);

                if (UserRoleRecord != null)
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


    }
}
