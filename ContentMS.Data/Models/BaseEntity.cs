using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Data.Models
{
    public class BaseEntity
    {
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
