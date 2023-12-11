using FroumSite.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class RegisterViewModel
    {

        [MaxLength(20, ErrorMessage = "نام نباید بیشتر از 20 حرف باشد")]
        [MinLength(3, ErrorMessage = "نام باید بیشتر از 2 حرف باشد")]
        [Display(Name = "نام")]
        [Required]
        public string Name { get; set; }


        [MaxLength(20, ErrorMessage = "فامیل نباید بیشتر از 20 حرف باشد")]
        [MinLength(3, ErrorMessage = "فامیل باید بیشتر از 5 حرف باشد")]
        [Display(Name = "فامیل")]
        public string Family { get; set; }


        [Display(Name = "تاریخ تولد")]
        public DateTime Birthday { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا جنسیت خود را انتخاب کنید")]
        public Sex Sex { get; set; }


        [StringLength(11, ErrorMessage = "شماره تلفن همراه باید 11 رقم باشد")]
        [Display(Name = "شماره تلفن همراه")]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(15, ErrorMessage = "رمز نباید بیشتر از 15 حرف باشد")]
        [MinLength(5, ErrorMessage = "رمز حداقل باید 5 حرف باشد")]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [StringLength(11, ErrorMessage = "شماره تلفن همراه باید 11 رقم باشد")]
        [Display(Name = "شماره تلفن همراه")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { get; set; }
    }
}
