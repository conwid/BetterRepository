using BetterRepository.BetterRepositories;
using BetterRepository.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.Sample.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
