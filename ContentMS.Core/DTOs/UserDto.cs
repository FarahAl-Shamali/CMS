using ContentMS.Core.Enums;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContentMS.Core.DTOs
{
    public class UserDto
    {

        public string Id { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }
        [Display(Name = " الصورة")]
        public IFormFile Image { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name = "نوع المستخدم")]
        public UserType UserType { get; set; }


    }
}
