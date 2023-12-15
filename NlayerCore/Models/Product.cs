using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCore.Model
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } //foreign key
        public Category? Category { get; set; }//bire cok ilişki
        public ProductFeaure? ProductFeaure { get; set; }
    }
}
