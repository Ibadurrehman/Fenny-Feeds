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
    [AllowAnonymous]
    public class Donate_BloodController : Controller
    {
        //
        // GET: /Donate_Blood/
        private _IAllRepository<FF_Donate_Blood> interfaceobj;
        private _IAllRepository<FF_Pet_Details> interfaceobj_Pet_Details;

        public Donate_BloodController()
        {
            this.interfaceobj = new AllRepository<FF_Donate_Blood>();
            this.interfaceobj_Pet_Details = new AllRepository<FF_Pet_Details>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonateBlood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DonateBlood(VM_Donate_Blood donate)
        {
            try
            {

                var CheckEmailExist = interfaceobj.GetModel().FirstOrDefault(a => a.Email_ID == donate.Email_ID);
                if (CheckEmailExist != null)
                {
                    //    [{\"Action\":\"error\",\"msg\":\"You have entered wrong email id password combination.\"}]
                    return Json("emailexist", JsonRequestBehavior.AllowGet);
                }

                FF_Donate_Blood db = new FF_Donate_Blood();
                db.UserName = donate.UserName;
                db.Email_ID = donate.Email_ID;
                db.Mobile = donate.Mobile;
                db.Address = donate.Address;
                db.PinCode = donate.PinCode;
                db.City = donate.City;
                db.State = donate.State;
                db.Creation_Date = DateTime.UtcNow;

                interfaceobj.InsertModel(db);
                interfaceobj.Save();

                FF_Pet_Details pd = new FF_Pet_Details();
                pd.User_ID = db.ID;
                pd.Pet_Name = donate.Pet_Name;
                pd.Pet_Breed = donate.Pet_Breed;
                pd.Pet_Gender = donate.Pet_Gender;
                pd.Pet_Age = donate.Pet_Age;
                pd.Pet_Weight = donate.Pet_Weight;

                interfaceobj_Pet_Details.InsertModel(pd);
                interfaceobj_Pet_Details.Save();

                return Json("done", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }



        public ActionResult BloodDonarList()
        {
            return View();
        }


        public ActionResult Get_BloodDonarList()
        {

            var donarList = interfaceobj.GetModel().AsEnumerable().Select(s => new
            {
                Donar_ID = s.ID,
                Donar_Name = s.UserName,
                Donar_Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = s.Address,
                City = s.City,
                Pet_Name = s.FF_Pet_Details.Select(d => d.Pet_Name),
                Pet_Breed = s.FF_Pet_Details.Select(d => d.Pet_Breed)
            });

            return Json(donarList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetBloodDonar_Records()
        {
            string Donar_Id = Request.QueryString["Donar_Id"];

            var donarrecord = interfaceobj.GetModel().Where(a => a.ID == Convert.ToInt32(Donar_Id)).AsEnumerable();

            var donarrecordList = donarrecord.Select(s => new
            {
                DonarID = s.ID,
                DonarName = s.UserName,
                Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = s.Address,
                City = s.City,
                State = s.State,
                Creation_Date = (s.Creation_Date.HasValue ? s.Creation_Date.Value.ToString("dd-MMM-yyyy") : "-"),
                PetName = s.FF_Pet_Details.Select(d => d.Pet_Name),
                PetBreed = s.FF_Pet_Details.Select(d => d.Pet_Breed),
                PetGender = s.FF_Pet_Details.Select(d => Enum.GetName(typeof(Enums.Gender), Convert.ToInt32(d.Pet_Gender))),
                PetAge = s.FF_Pet_Details.Select(d => d.Pet_Age),
                PetWeight = s.FF_Pet_Details.Select(d => d.Pet_Weight)

            });
            return Json(donarrecordList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteDonarSingleRecord()
        {
            string Donar_Id = Request.QueryString["Donar_Id"];

            var DonarRecord = interfaceobj.GetModel().FirstOrDefault(s => s.ID == Convert.ToInt32(Donar_Id));

            if (DonarRecord != null)
            {
                interfaceobj.DeleteModel(Convert.ToInt32(Donar_Id));
                interfaceobj.Save();

                return Json("done", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteBloodDonarMultipleRecord(string DonarIds)
        {
            try
            {
                List<string> collection = DonarIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var DonarRecord = interfaceobj.GetModel().Where(s => collection.Contains(s.ID.ToString()));

                foreach (var item in DonarRecord)
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
