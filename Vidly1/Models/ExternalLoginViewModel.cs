using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    //20190605 ExternalLogin classes moved from AccountViewModel ...
    public class ExternalLoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        // 20190602 Adding Profile Data.Including DrivingLicense used when login with Facebook ...
        [Required]
        [Display(Name = "Diving License")]
        public string DrivingLicense { get; set; }
        // 20190605 Adding Profile Data.Including Phone used when login with Facebook ...
        [Required]
        public string Phone { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}