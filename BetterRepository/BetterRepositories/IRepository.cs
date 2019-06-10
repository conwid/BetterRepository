using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.BetterRepositories
{
    public interface IRepository<T> : IOrderedQueryable<T> where T : class
    {        
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);          
    }
}
