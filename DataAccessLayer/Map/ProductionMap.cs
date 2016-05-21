using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
    public class ProductionMap : EntityTypeConfiguration<Production>
    {
        public ProductionMap()
        {
            //Property(p => p.SerialNumber).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
            //        new IndexAttribute("Production_SerialNumber_Unique")
            //        {
            //            IsUnique = true
            //        }));
        }
    }
}
