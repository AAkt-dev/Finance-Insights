using AutoMapper;
using Finance_Insights.Contracts;
using Finance_Insights.Entities.Models;
using Finance_Insights.Service_Contracts;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager=repository;
            _loggerManager=logger;
            _mapper=mapper;
        }
        public Category AddCategory(CategoryDto category,Guid accountId,bool trackChanges)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            categoryEntity.AccountId = accountId;
            _repositoryManager.categoryRepository.AddCategory(categoryEntity);
            _repositoryManager.Save();
            return categoryEntity;
        }

        public void DeleteCategory(Guid CategoryId, bool trackChanges)
        {
            var categoryEntity = _repositoryManager.categoryRepository.GetCategory(CategoryId, trackChanges);
            if (categoryEntity == null)
            {
                throw new InvalidOperationException("Category does not Exist");
            }
            _repositoryManager.categoryRepository.DeleteCategory(categoryEntity);
            _repositoryManager.Save();
        }

        public (CategoryDto categoryForPatch, Category categoryEntity) GetCategoryforPatch(Guid categoryId, bool trackChanges)
        {
            var category=_repositoryManager.categoryRepository.GetCategory(categoryId,trackChanges);
            if(category == null)
            {
                throw new InvalidOperationException("Category does not exist");
            }
            var categoryToPatch = _mapper.Map<CategoryDto>(category);
            return (categoryToPatch, category);
        }

        public IEnumerable<CategoryDto> GetAllAccountofCategory(Guid accountId, bool trackChanges)
        {
            var categories= _repositoryManager.categoryRepository.GetAllCategoryOfAccount(accountId, trackChanges);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategory(Guid categoryId,bool trackChanges)
        {
            var category = _repositoryManager.categoryRepository.GetCategory(categoryId,trackChanges);
            if (category == null)
            {
                throw new InvalidOperationException("Category does not exist");
            }
            return _mapper.Map<CategoryDto>(category);
        }

        public void SaveChangesForPatch(CategoryDto categoryForUpdateDto, Category category)
        {
            _mapper.Map(categoryForUpdateDto, category);
            _repositoryManager.Save();
        }
    }
}
