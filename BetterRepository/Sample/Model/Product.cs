using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetterRepository.Sample.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
