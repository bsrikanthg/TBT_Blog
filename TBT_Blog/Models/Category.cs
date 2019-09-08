using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public string CategoryOS { get; set; }
        public string CategoryDescription { get; set; }
    }
}