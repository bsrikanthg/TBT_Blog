using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TBT_Blog.Dtos
{
    public class AuthorLikedPostDto
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int[] PostIds { get; set; }

        public DateTime DateLiked { get; set; }

    }
}