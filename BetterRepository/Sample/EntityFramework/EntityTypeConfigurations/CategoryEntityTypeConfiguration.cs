using BetterRepository.Sample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.Sample.EntityFramework.EntityTypeConfigurations
{
    public class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration()
        {
            this
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            this
                .Property(e => e.Picture)
                .HasColumnType("image");

        }
    }
}
