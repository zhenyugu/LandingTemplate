using DataAccessLayer.Map;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomizedDbContext : IdentityDbContext<IdentityUser>
    {

        public CustomizedDbContext()
            : base("jjDbContext")
        {
           Database.SetInitializer(new DbInitializer());   
        }
        public IDbSet<T> GetEntity<T>() where T : class
        {
            return Set<T>();
        }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductionMap());
            modelBuilder.Configurations.Add(new ProductionImageMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
