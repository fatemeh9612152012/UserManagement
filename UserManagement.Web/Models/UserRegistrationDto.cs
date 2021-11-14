using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "نام الزامی است")]
        [Display(Description = "نام")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [Display(Description = "نام خانوادگی")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "تاریخ تولد الزامی است")]
        [Display(Description = "تاریخ تولد")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "آدرس الزامی است")]
        [Display(Description = "آدرس")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "جنسیت الزامی است")]
        [Display(Description = "جنسیت")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Description = "نام کاربری")]
        [StringLength(100)]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "پست الکترونیک صحیح نیست")]
        [Display(Description = "پست الکترونیک")]
        [Required(ErrorMessage = "پست الکترونیک الزامی است")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        [Display(Description = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار کلمه عبور الزامی است")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور باید با کلمه عبور یکسان باشد")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "شماره الزامی است")]
        [Display(Description = "شماره")]
        public string PhoneNumber { get; set; }

        public List<SelectListItem> GenderType2 { get; set; } = new List<SelectListItem>
        {
           new SelectListItem(GenderType.Famale.ToString(), ((int)GenderType.Famale).ToString()),
           new SelectListItem(GenderType.Male.ToString(), ((int)GenderType.Male).ToString()),
        };
    }

}
