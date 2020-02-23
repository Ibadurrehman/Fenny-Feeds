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
    [AllowAnonymous]
    public class Search_BloodController : Controller
    {
        private _IAllRepository<FF_Donate_Blood> interfaceobj;

        public Search_BloodController()
        {
            this.interfaceobj = new AllRepository<FF_Donate_Blood>();
        }

        //
        // GET: /Search_Blood/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchBlood()
        {
            return View();
        }


        public ActionResult SearchBloodDonarRecords()
        {
            string Pet_Breed = Request.QueryString["Pet_Breed"];
            string City = Request.QueryString["City"];

            var getDonarRecord = interfaceobj.GetModel().Where(w => w.City.Equals(City) && w.FF_Pet_Details.FirstOrDefault().Pet_Breed.Equals(Pet_Breed)).Select(s => new
            {
                DonarID = s.ID,
                DonarName = s.UserName,
                Email = s.Email_ID,
                Mobile = s.Mobile,
                Address = s.Address,
                City = s.City,
                State = s.State,
                //Creation_Date = (s.Creation_Date.HasValue ? s.Creation_Date.Value.ToString("dd-MMM-yyyy") : "-"),
                PetName = s.FF_Pet_Details.Select(d => d.Pet_Name),
                PetBreed = s.FF_Pet_Details.Select(d => d.Pet_Breed),
                PetGender = s.FF_Pet_Details.Select(d => Enum.GetName(typeof(Enums.Gender), Convert.ToInt32(d.Pet_Gender))),
                PetAge = s.FF_Pet_Details.Select(d => d.Pet_Age),
                PetWeight = s.FF_Pet_Details.Select(d => d.Pet_Weight)
            });

            return Json(getDonarRecord, JsonRequestBehavior.AllowGet);
        }
    }
}
