using Finance_Insights.Entities.Models;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.Service_Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllAccountofCategory(Guid accountId, bool trackChanges);
        CategoryDto GetCategory(Guid categoryId,bool tracChanges);
        Category AddCategory(CategoryDto category,Guid accountId,bool trackChanges);
        void DeleteCategory(Guid CategoryId,bool trackChanges);
        (CategoryDto categoryForPatch, Category categoryEntity) GetCategoryforPatch(Guid categoryId, bool trackChanges);
        void SaveChangesForPatch(CategoryDto categoryForUpdate, Category category);
    }
}
