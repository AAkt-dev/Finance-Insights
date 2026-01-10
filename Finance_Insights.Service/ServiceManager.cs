using AutoMapper;
using Finance_Insights.Contracts;
using Finance_Insights.Service_Contracts;

namespace Finance_Insights.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repository,ILoggerManager logger,IMapper mappers)
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repository, logger, mappers));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository, logger, mappers));
        }
        public IAccountService accountService => _accountService.Value;
        public ICategoryService categoryService => _categoryService.Value;
    }
}
