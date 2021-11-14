using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models
{
    public class UserShowDto
    {
        [Display(Description ="شناسه")]
        public int Id { get; set; }

        [Display(Description = "نام")]
        public string FirstName { get; set; }

        [Display(Description = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Description = "تاریخ تولد")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Description = "آدرس")]
        public string Address { get; set; }

        [Display(Description = "جنسیت")]
        public GenderType Gender { get; set; }

        [Display(Description = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Description = "پست الکترونیک")]
        public string Email { get; set; }

        [Display(Description = "شماره")]
        public string PhoneNumber { get; set; }
    }
}
