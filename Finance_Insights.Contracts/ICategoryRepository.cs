using Finance_Insights.Entities.Models;

namespace Finance_Insights.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategoryOfAccount(Guid accountId,bool trackChanges);

        Category GetCategory(Guid accountId,Guid CategoryId,bool trackChanges);

        void AddCategory(Category category);
        void DeleteCategory(Category category);

    }
}
