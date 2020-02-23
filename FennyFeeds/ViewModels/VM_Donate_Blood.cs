using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_Donate_Blood// : VM_LayoutMaster
    {
        //public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile no.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Enter Valid Mobile no.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Pincode")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public string State { get; set; }

        //public System.DateTime Creation_Date { get; set; }

        [Required(ErrorMessage = "Please Enter Your Pet's Name")]
        public string Pet_Name { get; set; }
        [Required(ErrorMessage = "Please Select Your Pet's Breed")]
        public string Pet_Breed { get; set; }
        [Required(ErrorMessage = "Please Select Your Pet's Gender")]
        public string Pet_Gender { get; set; }
        [Required(ErrorMessage = "Please Select Your Pet's Age")]
        public string Pet_Age { get; set; }
        [Required(ErrorMessage = "Please Select Your Pet's Weight")]
        public string Pet_Weight { get; set; }
    }
}