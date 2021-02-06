using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } 
    }
}
