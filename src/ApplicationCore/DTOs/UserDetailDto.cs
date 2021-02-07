using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTOs
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public AddressDetailDto Address { get; set; }
        public CompanyDetailDto Company { get; set; }
    }
}
