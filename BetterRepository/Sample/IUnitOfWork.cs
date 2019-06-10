using BetterRepository.Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.Sample
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get;  }
        IProductRepository Products { get; }
        Task CommitAsync();
    }
}
