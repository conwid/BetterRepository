using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.BetterRepositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> targetDbSet;             
        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.targetDbSet = dbContext.Set<T>();
            Expression = Expression.Constant(this);
            this.Provider = new RepositoryBaseQueryProvider<T>(targetDbSet);
        }
        public RepositoryBase(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression;
        }
        public Type ElementType => typeof(T);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
        public IEnumerator<T> GetEnumerator() => Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(T entity)
        {
            targetDbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            var entry = dbContext.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                targetDbSet.Attach(entity);
            }
            entry.State = EntityState.Deleted;
        }
        public void Update(T entity)
        {
            var entry = dbContext.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                targetDbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }                
    }
}
