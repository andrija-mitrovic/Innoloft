using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTOs
{
    public class AddressDetailDto
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoDetailDto Geo { get; set; }
    }
}
