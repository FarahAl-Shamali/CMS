using ContentMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DOB { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserType UserType { get; set; }

    }
}
