using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
        public int GeoId { get; set; }
        public User User { get; set; }
    }
}
