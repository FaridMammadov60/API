using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
