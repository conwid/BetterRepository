namespace BetterRepository.Sample.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BetterRepository.Sample.Model;
    using BetterRepository.Sample.EntityFramework.EntityTypeConfigurations;

    public partial class ApplicationContext : DbContext
    {
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(null);
        }
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityTypeConfiguration());
        }
    }
}
