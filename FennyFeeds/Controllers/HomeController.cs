using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Get_All_FeaturedProducts()
        {
            using (DataContext dc = new DataContext())
            {
                var get_allfeatured_category = dc.FF_HomePage_Display_Product.ToList();

                System.Text.StringBuilder Build = new System.Text.StringBuilder();

                //Check Local Path Or Server Path
                string rootpath = Utility_FF.Root_Path();

                foreach (var item in get_allfeatured_category)
                {
                    var getproduct = dc.FF_Products.Where(s => s.Category_ID == item.Category_ID);

                    if (getproduct.Count() > 0)
                    {
                        Build.Append("<div class='row'>");
                        Build.Append("<h2 class='head_collections'>" + item.Title + "<span>Food Product</span></h2>");
                        Build.Append("</div>");
                        Build.Append("<div class='row'>");
                        Build.Append("<div class='owl-carousel owl-theme owl-featured' id='FeaturedProperties'>");

                        foreach (var item1 in getproduct)
                        {
                            string firstimage = "";
                            string secondimage = "";

                            var ProductAllImages = MyHelperClass.GetProduct_Images(item1.ID);

                            if (ProductAllImages.Count() > 0)
                            {
                                firstimage = rootpath + "/Product_Image/" + item1.ID + "/" + ProductAllImages[0];
                                if (ProductAllImages.Count() > 1)
                                {
                                    secondimage = rootpath + "/Product_Image/" + item1.ID + "/" + ProductAllImages[1];
                                }

                            }
                            else
                            {
                                firstimage = rootpath + "/Product_Image/no_image.jpg";
                                secondimage = rootpath + "/Product_Image/no_image.jpg";
                            }
                            Build.Append("<div class=''>");
                            Build.Append("<div class='product-grid7'>");
                            Build.Append("<div class='product-image7'>");
                            Build.Append("<a href='../Master/ProductDetails?Product_ID=" + item1.ID + "'>");
                            Build.Append("<img class='pic-1' src='" + firstimage + "'>");//../content/Product_Image/" + item1.ID + "/Image-1.jpg
                            Build.Append("<img class='pic-2' src='" + secondimage + "'>");
                            Build.Append("</a>");
                            Build.Append("<ul class='social'>");
                            Build.Append("<li><a href='' class='mdi mdi-magnify' onclick='Get_ProductQuickView(" + item1.ID + ")' data-toggle='modal' data-target=''></a></li>");
                            Build.Append("<li><a href='' class='mdi mdi-heart' onclick=CheckUserLoginOrNot('addproduct_to_wishlist','" + item1.ID + "') data-toggle='modal' data-target=''></a></li>");
                            Build.Append("<li><a href='' class='mdi mdi-cart' data-toggle='modal' data-target='#slidermodal'></a></li>");
                            Build.Append("</ul>");
                            Build.Append("</div>");
                            Build.Append("<div class='product-content'>");
                            Build.Append("<h3 class='title'><a href='#'>" + item1.Product_Name + "</a></h3>");
                            Build.Append("");
                            Build.Append("<div class='price'>");
                            Build.Append("<span class='featured-price wrap-text'><i class='mdi mdi-currency-inr mr-2'></i>" + item1.Price + "</span>");
                            Build.Append("</div>");
                            Build.Append("</div>");
                            Build.Append("</div>");
                            Build.Append("</div>");

                        }

                        Build.Append("</div>");
                        Build.Append("</div>");

                    }

                }

                return Json(Build.ToString(), JsonRequestBehavior.AllowGet);

            }

        }

    }
}
