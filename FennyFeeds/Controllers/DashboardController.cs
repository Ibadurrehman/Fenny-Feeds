using FennyFeeds.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [SessionTimeout]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload_ProductImage()
        {
            try
            {
                //Banner Image Uploding code
                int filecount = Request.Files.Count;
                if (filecount > 0)
                {
                    //  Get all files from Request object  
                    //HttpPostedFileBase postedfile = Request.Files[0];
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase postedfile = files[i];

                        string savepath = HttpContext.Server.MapPath("~/content/Banner_Image/");
                        if (System.IO.Directory.Exists(savepath))
                        {
                            //savepath += "Product_Image/";
                            //if (!System.IO.Directory.Exists(savepath))
                            //{
                            //    System.IO.Directory.CreateDirectory(savepath);
                            //}
                            //int ProductID = p.ID;

                            //savepath += ProductID + "/";
                            if (!System.IO.Directory.Exists(savepath))
                            {
                                System.IO.Directory.CreateDirectory(savepath);
                            }

                            int A = postedfile.FileName.LastIndexOf(".");
                            int length = postedfile.FileName.Length;
                            string extention = postedfile.FileName.Substring(A, length - A);

                            if (System.IO.File.Exists(savepath + "Image-" + i + ".jpg"))
                            {
                                System.IO.File.SetAttributes(savepath + "Image-" + i + ".jpg", System.IO.FileAttributes.Normal);
                                System.IO.File.Delete(savepath + "Image-" + i + ".jpg");
                            }

                            postedfile.SaveAs(savepath + "Image-" + i + ".jpg");


                        }
                    }
                    return Json("done", JsonRequestBehavior.AllowGet);
                }
               
            }
            catch (Exception)
            {
                Json("error", JsonRequestBehavior.AllowGet);
            }
            return Json("error", JsonRequestBehavior.AllowGet);

        }


        public ActionResult Get_BannerImages()
        {
            string[] ImageCollection = MyHelperClass.GetBanner_Images();

            return Json(ImageCollection, JsonRequestBehavior.AllowGet);
        }

    }
}
