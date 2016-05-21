using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
    public class ProductionImageMap : EntityTypeConfiguration<ProductionImage>
    {
        public ProductionImageMap()
        {
            Property(i => i.ImageAddress).IsRequired();
            HasRequired<Production>(i => i.Production).WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductionId)
                .WillCascadeOnDelete(true);

        }
    }
}
