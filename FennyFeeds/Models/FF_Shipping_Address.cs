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
    
    public partial class FF_Shipping_Address
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Contact { get; set; }
        public string Alternate_No { get; set; }
        public string Invoice_No { get; set; }
        public System.DateTime Purchase_Date { get; set; }
    
        public virtual FF_Registration FF_Registration { get; set; }
    }
}
