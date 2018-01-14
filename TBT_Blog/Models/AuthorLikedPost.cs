using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models
{
    public class AuthorLikedPost
    {
        public int Id { get; set; }
        [Required]
        public Author Author { get; set; }

        [Required]
        public Post Post { get; set; }

        public DateTime DateLiked { get; set; }

    }
}