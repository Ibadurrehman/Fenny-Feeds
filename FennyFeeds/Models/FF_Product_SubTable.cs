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
    
    public partial class FF_Product_SubTable
    {
        public int ID { get; set; }
        public int Product_Id { get; set; }
        public int Product_Variant_Id { get; set; }
        public Nullable<int> Variant_Value_Id { get; set; }
        public string Product_Size { get; set; }
        public string Product_Colour { get; set; }
        public string Product_Quantity { get; set; }
        public string Product_Weight { get; set; }
        public string Product_Price { get; set; }
    
        public virtual FF_Product_Variants FF_Product_Variants { get; set; }
        public virtual FF_Product_Variants FF_Product_Variants1 { get; set; }
        public virtual FF_Variants_Value FF_Variants_Value { get; set; }
    }
}