﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FroumSite.Models.Enums;

namespace FroumSite.Models
{
    public class User
    {
        public User()
        {
            SharedPosts = new List<Post>();
            SharedTopics = new List<Topic>();
        }


        [Key]
        public int Id { get; set; }


        [MaxLength(20,ErrorMessage ="نام نباید بیشتر از 20 حرف باشد")]
        [MinLength(3,ErrorMessage = "نام باید بیشتر از 2 حرف باشد")]
        [Display(Name="نام")]
        [Required]
        public string Name { get; set; }


        [MaxLength(20, ErrorMessage = "فامیل نباید بیشتر از 20 حرف باشد")]
        [MinLength(3, ErrorMessage = "فامیل باید بیشتر از 5 حرف باشد")]
        [Display(Name="فامیل")]
        public string Family { get; set; }


        [Display(Name="تاریخ عضویت")]
        [Required]
        public DateTime RegisterDate { get; set; }


        [Display(Name="سن")]
        public DateTime Birthday { get; set; }


        [Display(Name="جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Sex Sex { get; set; }


        [StringLength(11,ErrorMessage ="شماره تلفن همراه باید 11 رقم باشد")]
        [Display(Name="شماره تلفن همراه")]
        [Required]
        public string PhoneNumber { get; set; }


        [MaxLength(15,ErrorMessage ="رمز نباید بیشتر از 15 حرف باشد")]
        [MinLength(5,ErrorMessage = "رمز حداقل باید 5 حرف باشد")]
        [Display(Name="کلمه عبور")]
        [Required]
        public string Password { get; set; }

        [Display(Name="ادمین")]
        public bool IsAdmin { get; set; }


        #region Navigation Properties

        public List<Topic> SharedTopics { get; set; }
        public List<Post> SharedPosts { get; set; }
        public List<UserLikeTopic> LikedTopics { get; set; }
        public List<UserLikePost> LikedPosts { get; set; }


        #endregion
    }
}
