using Finance_Insights.Contracts;
using Finance_Insights.Entities.Models;

namespace Finance_Insights.Repository
{
    public class CategoryRepository :RepositoryBase<Category>, ICategoryRepository
    {
        
        public CategoryRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }

        public void AddCategory(Category category)=>Create(category);
        public void DeleteCategory(Category category)=>Delete(category);
        public IEnumerable<Category> GetAllCategoryOfAccount(Guid accountId, bool trackChanges)=>FindByCondition(c=>c.AccountId==accountId,trackChanges);
        public Category GetCategory(Guid accountId, Guid CategoryId, bool trackChanges)=>FindByCondition(c=>c.AccountId ==accountId && c.CategoryId==CategoryId,trackChanges).SingleOrDefault();
    }
}
