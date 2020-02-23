//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FennyFeeds.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FF_Registration
    {
        public FF_Registration()
        {
            this.FF_Account_Activity = new HashSet<FF_Account_Activity>();
            this.FF_Shipping_Address = new HashSet<FF_Shipping_Address>();
            this.FF_Wish_List = new HashSet<FF_Wish_List>();
            this.FF_User_Role = new HashSet<FF_User_Role>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email_ID { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Login_With { get; set; }
        public string Recovery_Link { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
    
        public virtual ICollection<FF_Account_Activity> FF_Account_Activity { get; set; }
        public virtual ICollection<FF_Shipping_Address> FF_Shipping_Address { get; set; }
        public virtual ICollection<FF_Wish_List> FF_Wish_List { get; set; }
        public virtual ICollection<FF_User_Role> FF_User_Role { get; set; }
    }
}
