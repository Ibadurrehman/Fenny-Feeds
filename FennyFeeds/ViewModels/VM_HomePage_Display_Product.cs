using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_HomePage_Display_Product : VM_Product
    {
        public int ID { get; set; }
        public int Category_ID { get; set; }
        [Required(ErrorMessage = "Please Select Product Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
         
    }

}