using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser() : base()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public GenderType Gender { get; set; }

    }
    public enum GenderType : byte
    {
        [Display(Name = "آقا")]
        Male = 1,

        [Display(Name = "خانم")]
        Famale = 2,
    }
}
