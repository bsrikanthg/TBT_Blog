using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace TBT_Blog.Models
{
    public class Post 
    {
        public int Id { get; set; }
        [Required]
        public string PostName { get; set; }
        public string PostNameForNavigation { get; set; }
        [Required]
        [AllowHtml]
        public string PostContent { get; set; }

        public string OneLineDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool NewVersionExists { get; set; }
        public int RedirectPostId { get; set; }
        public bool IsHidden { get; set; }
        public string HideReason { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public OS OS { get; set; }
        public int OSId { get; set; }

        public Expression Expression => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

  

        public Post ShallowCopy()
        {
            return (Post)this.MemberwiseClone();
        }

    }
}