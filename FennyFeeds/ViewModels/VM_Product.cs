using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.ViewModels
{
    public class VM_Product : Variant
    {
        public int ID { get; set; }
        public int Category_ID { get; set; }
        public int Sub_Category_ID { get; set; }
        public int Product_Variant_Id { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Select Sub Category")]
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string Product_Name { get; set; }
        public string Product_Code { get; set; }
        //[Required]
        public string Price { get; set; }
        //[Required]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please Enter Product Quantity")]
        public string Quantity { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Image { get; set; }
        //[Required(ErrorMessage = "Please Enter Product Discount")]
        public string Discount { get; set; }
        //public System.DateTime Creation_Date { get; set; }
        //public Nullable<bool> IsProduct_Hide { get; set; }

        public List<string> ImageCollection { get; set; }
        public string VariantCollection { get; set; }
        public List<VariantCollection> VariantCollectionList { get; set; }


    }
    public class VariantCollection
    {
        public int Product_Sub_Table_ID { get; set; }
        public string First_Input { get; set; }
        public string Second_Input { get; set; }
        public string Third_Input { get; set; }
        public string Fourth_Input { get; set; }
        //public string Quantity { get; set; }

        //public string Size { get; set; }
        //public string Colour { get; set; }
        //public string Weight { get; set; }
        //public string Price { get; set; }
        //public string Quantity { get; set; }

    }

    public class Variant
    {
        ////For Variant
        //[Required(ErrorMessage = "Please Enter Variant Name")]
        public string FirstVariant { get; set; }
        //[Required(ErrorMessage = "Please Enter Variant Name")]
        public string SecondVariant { get; set; }

        //[Required(ErrorMessage = "Please Enter Variant Name")]
        //public string first_inpt { get; set; }
        //[Required(ErrorMessage = "Please Enter Variant Name")]
        //public string Second_inpt { get; set; }
        //[Required(ErrorMessage = "Please Enter Variant Name")]
        //public string third_inpt { get; set; }
        //[Required(ErrorMessage = "Please Enter Variant Name")]
        //public string fourth_inpt { get; set; }

    }

}