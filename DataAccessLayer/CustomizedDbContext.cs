using DataAccessLayer.Map;
using DataAccessLayer.Model;
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
            : base("JadeDbContext")
        {
            Configuration.LazyLoadingEnabled = false; 
           Database.SetInitializer(new DbInitializer());   
        }
        public IDbSet<T> GetEntity<T>() where T : class
        {
            return Set<T>();
        }

        public IDbSet<Production> Productions { get; set; }

        public IDbSet<ProductionImage> ProductionImages { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductionMap());
            modelBuilder.Configurations.Add(new ProductionImageMap());
            base.OnModelCreating(modelBuilder);
        }

        public static CustomizedDbContext Create()
        {
            return new CustomizedDbContext();
        }
    }
}
