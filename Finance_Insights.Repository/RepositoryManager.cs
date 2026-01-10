using Finance_Insights.Contracts;

namespace Finance_Insights.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAccountRepository> _accountRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this._repositoryContext = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
        }

        public IAccountRepository accountRepository => _accountRepository.Value;

        public void Save()=>_repositoryContext.SaveChanges();
    }
}
