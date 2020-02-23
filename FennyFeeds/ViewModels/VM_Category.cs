using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_Category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Select Option")]
        public string IsActive { get; set; }
    }
}