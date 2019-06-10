using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BetterRepository.BetterRepositories
{
    public class RepositoryBaseQueryProvider<TEntity> : IQueryProvider where TEntity : class
    {
        private readonly Type queryType;
        private readonly DbSet<TEntity> targetDbSet;

        public RepositoryBaseQueryProvider(DbSet<TEntity> targetDbSet)
        {
            this.queryType = typeof(RepositoryBase<>);
            this.targetDbSet = targetDbSet;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var elementType = expression.Type.GetElementTypeForExpression();
            try
            {
                return (IQueryable)Activator.CreateInstance(queryType.MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public object Execute(Expression expression)
        {            
            try
            {
                return this.GetType().GetGenericMethod(nameof(Execute)).Invoke(this, new[] { expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        // See https://msdn.microsoft.com/en-us/library/bb546158.aspx for more details
        public TResult Execute<TResult>(Expression expression)
        {             
            IQueryable<TEntity> newRoot = targetDbSet;
            var treeCopier = new RootReplacingVisitor(newRoot);
            var newExpressionTree = treeCopier.Visit(expression);
            var isEnumerable = (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (isEnumerable)
            {
                return (TResult)newRoot.Provider.CreateQuery(newExpressionTree);
            }
            var result = newRoot.Provider.Execute(newExpressionTree);
            return (TResult)result;
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            var elementType = expression.Type.GetElementTypeForExpression();
            var type = queryType.MakeGenericType(elementType);
            return (IQueryable<T>)Activator.CreateInstance(type, new object[] { this, expression });
        }      
    }
}
