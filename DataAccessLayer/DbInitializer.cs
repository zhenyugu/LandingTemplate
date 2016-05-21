using DataAccessLayer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!initialized)
            {
                //InitializeData(context);
            }
        }

        //private void InitializeData(IdentityDbContext<IdentityUser> context)
        //{
        //    //context.Users.Add(new IdentityUser { UserName = "abc" });
        //}
    }
}
