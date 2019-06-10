using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterRepository.Sample.EntityFramework;
using BetterRepository.Sample.Repositories;

namespace BetterRepository.Sample
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        private readonly ApplicationContext context;
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public UnitOfWork(ICategoryRepository categoryRepository, IProductRepository productRepository, ApplicationContext context)
        {
            this.Categories = categoryRepository ?? throw new ArgumentNullException("categoryRepository");
            this.Products = productRepository ?? throw new ArgumentNullException("productRepository");
            this.context = context ?? throw new ArgumentNullException("context");
        }
    }
}
