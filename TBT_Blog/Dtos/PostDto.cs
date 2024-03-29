﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TBT_Blog.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        [Required]
        public string PostName { get; set; }
        [Required]
        [AllowHtml]
        public string PostContent { get; set; }

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
        public AuthorDto Author{ get; set; }
    }
}