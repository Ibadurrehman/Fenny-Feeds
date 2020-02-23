using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{

    public class VM_AdminSignup
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile no.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Enter Valid Mobile no.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        //[Compare("Customer.Password", ErrorMessage = "The fields Password and PasswordConfirmation should be equals")]
        //public string PasswordConfirmation { get; set; }
    }

    public class VM_AdminSignin
    {
        [Required(ErrorMessage = "Please Enter Valid Email Address")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

    }
}