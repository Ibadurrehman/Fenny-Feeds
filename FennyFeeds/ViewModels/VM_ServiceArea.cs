using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FennyFeeds.ViewModels
{
    public class VM_ServiceArea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Area Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Area Pincode")]
        [RegularExpression("^[0-9]{1,6}$", ErrorMessage = "Please Enter Valid PinCode")]
        public int PinCode { get; set; }
    }
}