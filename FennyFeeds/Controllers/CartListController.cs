using FennyFeeds.HelperClasses;
using FennyFeeds.Models;
using FennyFeeds.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.Controllers
{
    [AllowAnonymous]
    public class CartListController : Controller
    {
        private _IAllRepository<FF_Cart_List> interfaceobj;

        public CartListController()
        {
            this.interfaceobj = new AllRepository<FF_Cart_List>();
        }

        //
        // GET: /CartList/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CartList()
        {
            return View();
        }

        public ActionResult Get_Cart_List()
        {
            try
            {
                int UserID = Convert.ToInt32(SessionObject.userid ?? 0);

                if (UserID == 0)
                {
                    return RedirectToAction("../Home/Home");
                    //return Json("session_expire",JsonRequestBehavior.AllowGet);
                }

                var WishList = interfaceobj.GetModel().Where(a => a.User_ID == UserID).AsEnumerable();

                if (WishList.Count() > 0)
                {
                    StringBuilder Grids = new StringBuilder();

                    Grids.Append("<table class='table table-bordered order-table'>");
                    Grids.Append("<thead style='background-color: #f5f5f5'>");
                    Grids.Append("<tr>");
                    Grids.Append("<th class='width15'>Product");
                    Grids.Append("</th>");
                    Grids.Append("<th class='width30'>Product Name");
                    Grids.Append("</th>");
                    Grids.Append("<th class='width10'>Product Code");
                    Grids.Append("</th>");
                    Grids.Append("<th class='width10'>Quantity");
                    Grids.Append("</th>");
                    Grids.Append("<th class='width15'>Unit price");
                    Grids.Append("</th>");
                    Grids.Append("<th class='width10'>Discount %");
                    Grids.Append("</th>");
                    Grids.Append("@*<th class='width15'>Total");
                    Grids.Append("</th>*@");
                    Grids.Append("<th class='width5'></th>");
                    Grids.Append("</tr>");
                    Grids.Append("</thead>");
                    foreach (var item in WishList)
                    {
                        Grids.Append("<tbody>");
                        Grids.Append("<tr>");
                        Grids.Append("<td class='width15'>");
                        Grids.Append("<img class='responsive' alt='' src='~/content/images/s1.jpg'>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width30'>");
                        Grids.Append("<h4>" + item.FF_Products.Product_Name + "</h4>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width10' style='text-align: center;'>");
                        Grids.Append("<span class='label label-success'>" + item.FF_Products.Product_Code + "</span>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width10' style='text-align: center;'>");
                        Grids.Append("<span class='label label-success'>" + item.FF_Products.Quantity + "</span>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width15'>");
                        Grids.Append("<span>" + HelperClasses.Utility_FF.Currency + " " + item.FF_Products.Price + "</span>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width10'>");
                        Grids.Append("<span>" + (Convert.ToInt32(item.FF_Products.Discount) < 0 ? "-" : item.FF_Products.Discount + " %") + "</span>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width15'>");
                        Grids.Append("<span>" + (Convert.ToInt32(item.FF_Products.Discount) < 0 ? "-" : item.FF_Products.Discount + " %") + "</span>");
                        Grids.Append("</td>");
                        Grids.Append("<td class='width5'>");
                        Grids.Append("<span class='order-remove'><i class='mdi mdi-delete-forever'></i></span>");
                        Grids.Append("</td>");
                        Grids.Append("</tr>");
                        Grids.Append("</tbody>");

                        //Grids.Append("<tr>");
                        //Grids.Append("<td><img src='" + UtilityString.ImagePath(item.FF_Product.ID) + "' style='width:50px;' /></td>");
                        //Grids.Append("<td class='paddingtop20'>" + item.FF_Product.Product_Name + "</td>");
                        //Grids.Append("<td class='paddingtop20'>" + item.FF_Product.Product_Code + "</td>");
                        //Grids.Append("<td class='paddingtop20'>" + UtilityString.Currency + item.FF_Product.Price + ".00</td>");
                        ////Grids.Append("<td class='paddingtop20'>" + (item.FF_Product.Discount < 0 ? "-" : item.FF_Product.Discount + " %") + "</td>");
                        ////Grids.Append("<td class='paddingtop20'>" + UtilityString.Currency + FinalAmount + ".00</td>");
                        //Grids.Append("<td class='paddingtop20 text-center'><i class='glyphicon glyphicon-trash' onclick='RemoveProductFromWish_List(this," + item.ID + ")'></i></td>");
                        //Grids.Append("</tr>");

                    }
                    Grids.Append("</table>");

                    return Json(Grids, JsonRequestBehavior.AllowGet);
                }
                return Json("", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
