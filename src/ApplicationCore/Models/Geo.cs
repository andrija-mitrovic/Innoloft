using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Geo
    {
        public int GeoId { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Address Address { get; set; }
    }
}
