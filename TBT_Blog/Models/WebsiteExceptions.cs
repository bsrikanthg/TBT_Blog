using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models
{
    public class WebsiteExceptions
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string TargetSite { get; set; }
    }
}