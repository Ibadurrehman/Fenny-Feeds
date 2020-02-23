using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FennyFeeds.HelperClasses
{
    public class EmailTemplate
    {
        //public static string EmailCheck(IEnumerable<string> parameters)
        //{
        //    if (parameters.Count() == 3)
        //    {
        //        //string verifyLink = UtilityKW.ServerURL + "/verifyyouremail.aspx?verifyid=" + parameters.ElementAt(1);

        //        StringBuilder stringBuild = new StringBuilder();

        //        stringBuild.Append("<table width=\"650\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"background-color: #e0e0e0; padding: 20px; font-family: sans-serif;\">");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td>");
        //        stringBuild.Append("<table cellpadding=\"0\" cellspacing=\"0\" align=\"center\" width=\"100%\">");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td style=\"padding: 10px 0px 30px 0px; background-color: #fff; border-top: 3px solid #00496e;\">");
        //        stringBuild.Append("<div style=\"height: 50px; width: 100%; line-height: 50px; text-align: center;\">");
        //        stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\" target=\"_blank\">");
        //        stringBuild.Append("<img src=\"" + Utility_FF.ServerURL + "images/logo.jpg\" style=\"margin-top: 20px;padding-bottom:20px;\">");
        //        stringBuild.Append("</a>");
        //        stringBuild.Append("</div>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td>");
        //        stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\">");
        //        stringBuild.Append("<img src=\"" + Utility_FF.ServerURL + "images/banner1.jpg\" width=\"100%\" alt=\"\" /></a>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td style=\"background-color: #fff;\">");
        //        stringBuild.Append("<div style=\"padding: 15px; border-bottom: 1px solid #ddd;\">");
        //        stringBuild.Append("<h4 style=\"margin: 0; padding: 10px\">Hi " + parameters.ElementAt(0) + "</h4>");


        //        stringBuild.Append("<p style=\"font-size: 15px; padding: 10px; text-align: justify; line-height: 1.4em; margin: 0;\">");
        //        stringBuild.Append("Congratulations! You have successfully subscribed! Thanks for subscribing to our newsletter.");
        //        stringBuild.Append("</p>");

        //        stringBuild.Append("</div>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td style=\"background-color: #fff; padding-top: 10px;\">");
        //        stringBuild.Append("<div style=\"width: 100%; text-align: center;\">");
        //        stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\" target=\"_blank\"><img src=\"" + Utility_FF.ServerURL + "images/key-wealth-logo.png\" width=\"100px\" height=\"100px\" alt=\"\" />");
        //        stringBuild.Append("</a>");
        //        stringBuild.Append("</div>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td style=\"padding: 10px 0px 10px 0px; background-color: #fff; text-align: center;\">");
        //        stringBuild.Append("<ul style='padding:0;display:inline-block;margin:0'>");
        //        stringBuild.Append("<li style='list-style:none;float:left;padding:3px'><a href='https://www.facebook.com/Fenny-Feeds-1241744805924903/'><img src='" + Utility_FF.ServerURL + "images/fb.png' alt='' width='30px' height='30px' /></a></li>");
        //        stringBuild.Append("<li style='list-style:none;float:left;padding:3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/108306686058067343693'><img src='" + Utility_FF.ServerURL + "images/gp.jpg' alt='' width='30px' height='30px' /></a></li>");
        //        //stringBuild.Append("<li style='list-style:none;float:left;padding:3px'><a href='http://twitter.com/key_wealth'><img src='" + Utility_FF.ServerURL + "images/twitter.png' alt='' width='30px' height='30px' /></a></li>");
        //        //stringBuild.Append("<li style='list-style:none;float:left;padding:3px'><a href='http://www.youtube.com/keywealth'><img src='" + Utility_FF.ServerURL + "images/youtube.png' alt='' width='30px' height='30px' /></a></li>");
        //        stringBuild.Append("</ul>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("<tr>");
        //        stringBuild.Append("<td style=\"padding: 10px 0px 30px 0px; background-color: #fff; text-align: center;\">");
        //        stringBuild.Append("<span style=\"font-size: 12px\">Copyright © " + DateTime.Today.Year + ". All rights reserved.</span>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("</table>");
        //        stringBuild.Append("</td>");
        //        stringBuild.Append("</tr>");
        //        stringBuild.Append("</table>");

        //        return stringBuild.ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public static string EmailVerification_ForgotPassword(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 3)
            {
                //string ForgotPasswordLink = Utility_FF.ServerURL + "verifyEmailForgotPassword.aspx?verifyid=" + parameters.ElementAt(1);
                string ForgotPasswordLink = Utility_FF.ServerURL + "verifyEmailForgotPassword?verifyid=" + parameters.ElementAt(1);

                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table width=\"650\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"background-color: #e0e0e0; padding: 20px; font-family: sans-serif;\">");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<table cellpadding=\"0\" cellspacing=\"0\" align=\"center\" width=\"100%\">");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style=\"padding: 10px 0px 30px 0px; background-color: #fff; border-top: 3px solid #00496e;\">");
                stringBuild.Append("<div style=\"height: 50px; width: 100%; line-height: 50px; text-align: center;\">");
                stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\" target=\"_blank\">");
                stringBuild.Append("<img src=\"" + Utility_FF.ServerURL + "images/logo.jpg\" style=\"margin-top: 20px;\">");
                stringBuild.Append("</a>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\">");
                stringBuild.Append("<img src=\"" + Utility_FF.ServerURL + "images/banner1.jpg\" width=\"100%\" alt=\"\" /></a>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style=\"background-color: #fff;\">");
                stringBuild.Append("<div style=\"padding: 15px; border-bottom: 1px solid #ddd;\">");
                stringBuild.Append("<h4 style=\"margin: 0; padding: 10px\">Hi, " + parameters.ElementAt(0) + "</h4>");

                stringBuild.Append("<p style=\"font-size: 15px; padding: 10px; text-align: justify; line-height: 1.4em; margin: 0;\">");
                stringBuild.Append("On successfully completing this verification, your password will be activated");
                stringBuild.Append("</p>");


                stringBuild.Append("<p style=\"font-size: 15px; padding: 10px; text-align: justify; line-height: 1.4em; margin: 0;\">");
                stringBuild.Append("We have received a request to reset the password for your account. If you requested a reset password for " + parameters.ElementAt(2) + ", click the button below.If you didn’t make this request, please ignore this email.");
                stringBuild.Append("</p>");

                stringBuild.Append("<p style=\"padding: 10px; text-align: center; margin: 0;\">");
                stringBuild.Append("<a href=\"" + ForgotPasswordLink + "\" style=\"padding: 10px 20px; background-color: #ff8204; border: 1px solid #e67d22; border-radius: 2px; text-decoration: none; color: #fff; font-size: 14px;\">Change Password</a>");
                stringBuild.Append("</p>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style=\"background-color: #fff; padding-top: 10px;\">");
                stringBuild.Append("<div style=\"width: 100%; text-align: center;\">");
                stringBuild.Append("<a href=\"" + Utility_FF.ServerURL + "\" target=\"_blank\"><img src=\"" + Utility_FF.ServerURL + "images/key-wealth-logo.png\" width=\"100px\" height=\"100px\" alt=\"\" />");
                stringBuild.Append("</a>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style=\"padding: 10px 0px 30px 0px; background-color: #fff; text-align: center;\">");
                stringBuild.Append("<span style=\"font-size: 12px\">Copyright © " + DateTime.Today.Year + ". All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string RegistrationMailToUser(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 1)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden;font-size:16px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/banner1.jpg' alt='' width='100%' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 3%; padding-top: 0;text-align:left;'>");
                stringBuild.Append("<h2>Hello, " + parameters.ElementAt(0) + "</h2>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align:left;'>");
                stringBuild.Append("Welcome to Fenny Feeds. Your account at fennyfeeds.com has been created successfully. You may start using your account now.");
                stringBuild.Append("You can log in by clicking the link below.");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align:center;'>");
                stringBuild.Append("<a href='" + Utility_FF.ServerURL + "'>" + Utility_FF.ServerURL + "</a>");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }


        public static string RegistrationMailToAdmin(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 1)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden;font-size:16px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 3%; padding-top: 0;text-align:left;'>");
                stringBuild.Append("<h2>Hello, Admin</h2>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align:left;'>");
                stringBuild.Append("One User  " + parameters.ElementAt(0) + " registered successfully to fenny feeds");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string SubscriptionMailToUser(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 1)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden; font-size: 16px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/subscribe.jpg' alt='' width='100%' height='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("<h4>Hi, <a href='' target='_blank'>" + parameters.ElementAt(0) + "</a></h4>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("Congratulations! You have successfully subscribed! Thanks for subscribing to our newsletter. We will always update you with the all new products.");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: center;'>");
                stringBuild.Append("<a href='" + Utility_FF.ServerURL + "'>" + Utility_FF.ServerURL + "</a>");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string SubscriptionMailToAdmin(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 1)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden; font-size: 16px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("<h4>Hi, Admin</h4>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("One User " + parameters.ElementAt(0) + " Subscribe successfully.");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: center;'>");
                stringBuild.Append("<a href='" + Utility_FF.ServerURL + "'>" + Utility_FF.ServerURL + "</a>");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px'height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string ContactUsMailToAdmin(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 4)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden; font-size: 16px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("<h4>Hi, Admin</a></h4>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("There is one query from contact us form, the details are shown below.");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0; text-align: left;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: solid thin #ccc; overflow: hidden; font-size: 14px;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='width: 20%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>UserName</td>");
                stringBuild.Append("<td style='width: 80%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>" + parameters.ElementAt(0) + "</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='width: 20%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>Email</td>");
                stringBuild.Append("<td style='width: 80%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>" + parameters.ElementAt(1) + "</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='width: 20%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>Subject</td>");
                stringBuild.Append("<td style='width: 80%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>" + parameters.ElementAt(2) + "</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='width: 20%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>Message</td>");
                stringBuild.Append("<td style='width: 80%; padding: 5px; border-bottom: solid thin #ccc; border-right: solid thin #ccc'>" + parameters.ElementAt(3) + "</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string InvoiceMailToUser(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 2)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/subscribe.jpg' alt='' width='100%' height='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; font-weight: bold;'>");
                stringBuild.Append("Hi " + parameters.ElementAt(0) + "");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0;'>");
                stringBuild.Append("Your recent order on fenny feeds has been received successfully. Your order details are show below for your reference:");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div>" + parameters.ElementAt(1) + "</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string InvoiceMailToAdmin(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 2)
            {
                StringBuilder stringBuild = new StringBuilder();

                stringBuild.Append("");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' style='background-color: #f7f7f7; width: 700px; height: auto; margin: auto;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 2%;'>");
                stringBuild.Append("<table cellpadding='0' cellspacing='0' width='100%' style='background-color: #fff; border: 1px solid #efefef; overflow: hidden;'>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center; text-align: center; padding: 15px; background-color: #fff;'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/logo.jpg' alt='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='text-align: center'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/subscribe.jpg' alt='' width='100%' height='' />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; font-weight: bold;'>");
                stringBuild.Append("Hi Admin");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div style='padding: 3%; padding-top: 0;'>");
                stringBuild.Append("One order on fenny feeds has been received successfully. Your order details are show below:");
                stringBuild.Append("<br />");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td>");
                stringBuild.Append("<div>" + parameters.ElementAt(1) + "</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='padding: 10px 0px 10px 0px; background-color: #fff; text-align: center; border-top: 1px solid #e5e5e5;'>");
                stringBuild.Append("<ul style='padding: 0; display: inline-block; margin: 0'>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.facebook.com/FennyFeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-facebook.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://twitter.com/FennyFeeds'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-twitter.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://www.instagram.com/fennyfeeds/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-instagram.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("<li style='list-style: none; float: left; padding: 3px'><a href='https://plus.google.com/u/0/b/108306686058067343693/'>");
                stringBuild.Append("<img src='" + Utility_FF.ServerURL + "images/new-googleplus.png' alt='' width='30px' height='30px' /></a></li>");
                stringBuild.Append("</ul>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("<tr>");
                stringBuild.Append("<td style='text-align: center; padding-top: 0px; padding-bottom: 20px;'>");
                stringBuild.Append("<span style='font-size: 12px'>Copyright © 2017. All rights reserved.</span>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");
                stringBuild.Append("</div>");
                stringBuild.Append("</td>");
                stringBuild.Append("</tr>");
                stringBuild.Append("</table>");

                return stringBuild.ToString();
            }
            else
            {
                return null;
            }
        }

    }
}