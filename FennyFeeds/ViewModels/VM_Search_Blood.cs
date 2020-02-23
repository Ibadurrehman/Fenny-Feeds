using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_Search_Blood
    {
        [Required(ErrorMessage = "Please Select Your Pet's Breed")]
        public string Pet_Breed { get; set; }
        [Required(ErrorMessage = "Please Select Your City")]
        public string City { get; set; }

    }
}