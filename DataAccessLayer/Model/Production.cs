using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Production
    {
        public Production()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public string Size { get; set; }

        public string Author { get; set; }

        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductionImage> Images { get; set; }
    }
}
