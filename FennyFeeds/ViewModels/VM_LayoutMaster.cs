using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_LayoutMaster
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }
        public System.DateTime Subscription_Date { get; set; }
    }
}