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
    
    public partial class FF_Sub_Category
    {
        public int ID { get; set; }
        public int Category_ID { get; set; }
        public string SubCategory { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual FF_Category FF_Category { get; set; }
    }
}