using System.Linq;
using System.Linq.Expressions;

namespace BetterRepository.BetterRepositories
{
    internal class RootReplacingVisitor : ExpressionVisitor
    {
        private readonly IQueryable newRoot;
        public RootReplacingVisitor(IQueryable newRoot)
        {
            this.newRoot = newRoot;
        }
        protected override Expression VisitConstant(ConstantExpression node) => 
             node.Type.BaseType!=null && node.Type.BaseType.IsGenericType && node.Type.BaseType.GetGenericTypeDefinition() == typeof(RepositoryBase<>) ? Expression.Constant(newRoot) : node;            
        
    }
}
