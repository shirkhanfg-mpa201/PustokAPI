using Pustok.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
