
using BetterRepository.Sample;
using BetterRepository.Sample.EntityFramework;
using BetterRepository.Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var x = new ApplicationContext())
            {
                IUnitOfWork uow = new UnitOfWork(new CategoryRepository(x), new ProductRepository(x), x);
                var s = uow.Categories.Where(c => c.CategoryId > 3).ToList();                
            }            
        }
    }
}
