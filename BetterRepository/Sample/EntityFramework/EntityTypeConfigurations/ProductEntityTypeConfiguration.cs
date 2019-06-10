using BetterRepository.Sample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.Sample.EntityFramework.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
            this
               .Property(e => e.UnitPrice)
               .HasPrecision(19, 4);

            this
                .Property(e => e.UnitPrice)
                .HasColumnType("money");
        }
    }
}
