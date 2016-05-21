using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ProductionImage
    {
        public ProductionImage()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string ImageAddress { get; set; }

        public string ProductionId { get; set; }

        public virtual Production Production { get; set; }
    }
}
