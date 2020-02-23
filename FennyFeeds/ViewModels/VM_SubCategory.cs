using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_SubCategory
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public int Category_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Sub Category")]
        public string SubCategory { get; set; }
        [Required(ErrorMessage = "Please Select Option")]
        public string IsActive { get; set; }
    }
}