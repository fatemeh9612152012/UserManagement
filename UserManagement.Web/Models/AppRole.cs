using Microsoft.AspNetCore.Identity;

namespace UserManagement.Web.Models
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {

        }


        public AppRole(string name) : base(name)
        {

        }

    }
}
