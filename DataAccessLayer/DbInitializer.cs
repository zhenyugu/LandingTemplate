using DataAccessLayer.Identity;
using DataAccessLayer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DataAccessLayer
{
    public class DbInitializer : 
        MigrateDatabaseToLatestVersion<CustomizedDbContext,Configuration>
    {
        public override void InitializeDatabase(CustomizedDbContext context)
        {
            
            base.InitializeDatabase(context);
            var migrator = new DbMigrator(new Configuration());
            var initialized = migrator.GetDatabaseMigrations().Any();
            InitializeData(context);

        }

        private void InitializeData(IdentityDbContext<IdentityUser> context)
        {
            if (context.Users.Any(u => u.UserName == "admin@1234.com"))
            {
                return;
            }

            var userManager = new CustomizedUserManager(new UserStore<IdentityUser>(context));
            var user = new IdentityUser(){
                UserName = "admin@1234.com",
                 Email = "admin@1234.com"
            };
            userManager.Create(user, "abc@1234");
        }
    }
}
