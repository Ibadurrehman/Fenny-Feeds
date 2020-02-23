using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FennyFeeds.HelperClasses
{
    public class SessionObject
    {
        public static object userid { get { return System.Web.HttpContext.Current.Session[SessionNames.USERID.ToString()]; } }
        public static object userscreenname { get { return System.Web.HttpContext.Current.Session[SessionNames.USERSCREENNAME.ToString()]; } }
        public static object username { get { return System.Web.HttpContext.Current.Session[SessionNames.USERNAME.ToString()]; } }
        public static object tempusername { get { return System.Web.HttpContext.Current.Session[SessionNames.TEMPUSERNAME.ToString()]; } }
        public static object useremail { get { return System.Web.HttpContext.Current.Session[SessionNames.USEREMAIL.ToString()]; } }
        public static object userrole { get { return System.Web.HttpContext.Current.Session[SessionNames.USERROLE.ToString()]; } }
        public static object usertimezone { get { return System.Web.HttpContext.Current.Session[SessionNames.USERTIMEZONE.ToString() ?? "0"]; } }

        //public static object IsMember { get { return System.Web.HttpContext.Current.Session[SessionNames.ISMEMBER.ToString()]; } }

        //public static object IpCountry { get { return System.Web.HttpContext.Current.Session[SessionNames.IPCOUNTRY.ToString()]; } }
        //public static object IpCity { get { return System.Web.HttpContext.Current.Session[SessionNames.IPCITY.ToString()]; } } 
        //public static object Currency { get { return System.Web.HttpContext.Current.Session[SessionNames.CURRENCY.ToString()] ?? ""; } }
        public static object superadminid { get { return System.Web.HttpContext.Current.Session[SessionNames.SUPERADMINID.ToString()]; } }
        public static object superadminemailid { get { return System.Web.HttpContext.Current.Session[SessionNames.SUPERADMINEMAILID.ToString()]; } }
        public static object superadminscreenname { get { return System.Web.HttpContext.Current.Session[SessionNames.SUPERADMINSCREENNAME.ToString()]; } }
        public static object superadminname { get { return System.Web.HttpContext.Current.Session[SessionNames.SUPERADMINNAME.ToString()]; } }

    }

    public enum SessionNames
    {
        USERID,
        USERSCREENNAME,
        USEREMAIL,
        USERNAME,
        USERROLE,
        TEMPUSERNAME,
        //ISMEMBER,
        //IPCOUNTRY,
        //IPCITY,
        //CURRENCY,
        SUPERADMINID,
        SUPERADMINSCREENNAME,
        SUPERADMINEMAILID,
        SUPERADMINNAME,
        USERTIMEZONE
    }
}