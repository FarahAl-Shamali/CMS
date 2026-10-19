using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContentMS.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public List<Post> Posts { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Email> Emails { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Advertisment> Advertisments { get; set; }

    }
}
