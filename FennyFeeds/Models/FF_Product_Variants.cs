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
    
    public partial class FF_Product_Variants
    {
        public FF_Product_Variants()
        {
            this.FF_Product_SubTable = new HashSet<FF_Product_SubTable>();
            this.FF_Product_SubTable1 = new HashSet<FF_Product_SubTable>();
            this.FF_Variants_Value = new HashSet<FF_Variants_Value>();
        }
    
        public int ID { get; set; }
        public int Product_Id { get; set; }
        public string Variants_Name { get; set; }
    
        public virtual ICollection<FF_Product_SubTable> FF_Product_SubTable { get; set; }
        public virtual ICollection<FF_Product_SubTable> FF_Product_SubTable1 { get; set; }
        public virtual FF_Product_Variants FF_Product_Variants1 { get; set; }
        public virtual FF_Product_Variants FF_Product_Variants2 { get; set; }
        public virtual ICollection<FF_Variants_Value> FF_Variants_Value { get; set; }
    }
}
