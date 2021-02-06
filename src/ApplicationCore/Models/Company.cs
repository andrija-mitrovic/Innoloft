using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        public User User { get; set; }
    }
}
