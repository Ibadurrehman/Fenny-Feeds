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
    
    public partial class FF_Donate_Blood
    {
        public FF_Donate_Blood()
        {
            this.FF_Pet_Details = new HashSet<FF_Pet_Details>();
        }
    
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email_ID { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
    
        public virtual ICollection<FF_Pet_Details> FF_Pet_Details { get; set; }
    }
}