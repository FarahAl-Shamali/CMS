using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContentMS.Data.Models
{
    public class PostAttachment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        [Required]

        public string AttachmenUrl { get; set; }
    }
}
