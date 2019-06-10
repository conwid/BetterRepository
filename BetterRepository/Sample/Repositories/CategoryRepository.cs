using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BetterRepository.BetterRepositories;
using BetterRepository.Sample.Model;

namespace BetterRepository.Sample.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
