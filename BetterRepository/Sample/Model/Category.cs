using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetterRepository.Sample.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
