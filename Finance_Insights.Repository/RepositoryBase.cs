using Finance_Insights.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finance_Insights.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;
        public RepositoryBase(RepositoryContext repository)
        {
            this.repositoryContext = repository;
        }
        public void Create(T entity)=>repositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? repositoryContext.Set<T>().AsNoTracking() : repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) => !trackChanges ? repositoryContext.Set<T>().Where(condition).AsNoTracking() : repositoryContext.Set<T>().Where(condition);

        public void Update(T entity) => repositoryContext.Set<T>().Update(entity);
    }
}
