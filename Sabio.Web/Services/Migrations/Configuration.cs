namespace MediaForAll.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MediaForAll.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MediaForAll.Web.Models.ApplicationDbContext context)
        {
            CreateRole(context, "Admin");
            CreateRole(context, "SuperAdmin");
            CreateRole(context, "User");

            string[] adminRoles = new string[] { "Admin", "SuperAdmin" };
            string[] userRoles = new string[] { "User" };

            CreateUser(context, "sabioInbox@mailinator.com", adminRoles);
            CreateUser(context, "sabioInstructor@mailinator.com", adminRoles);
            CreateUser(context, "sabioUser@mailinator.com", userRoles);

        }


        private static void CreateRole(ApplicationDbContext context, string roleName)
        {
            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = roleName };

                manager.Create(role);
            }
        }

        private static void CreateUser(ApplicationDbContext context, string userNameEmail, string[] roles)
        {
            if (!context.Users.Any(u => u.UserName == userNameEmail))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = userNameEmail,
                    Email = userNameEmail,
                    LockoutEnabled = false
                };

                manager.Create(user, "Sabiopass1!");
                manager.AddToRoles(user.Id, roles);
            }
        }
    }
}
