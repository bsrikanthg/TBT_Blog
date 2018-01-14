using System;
using System.ComponentModel.DataAnnotations;

namespace TBT_Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }
        public bool  IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public int RepliedToCommenterId { get; set; }
    }


}