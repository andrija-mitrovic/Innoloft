using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTOs
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactPerson { get; set; }
    }
}
