using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBT_Blog.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

    }


}