using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UserManagement.Web.Models;

namespace UserManagement.Web
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        

        private void OnModelCreatingSetting(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }


}


