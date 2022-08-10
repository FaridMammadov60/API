using System;

namespace API.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime  CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
