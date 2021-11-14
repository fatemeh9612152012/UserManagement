using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Web.Models
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Description = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        [Display(Description = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
