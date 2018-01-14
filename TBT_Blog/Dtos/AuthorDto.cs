using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBT_Blog.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
    }
}