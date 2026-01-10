using Finance_Insights.Contracts;
using Finance_Insights.Entities.Models;

namespace Finance_Insights.Repository
{
    public class AccountRepository :RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext context):base(context)
        {
            
        }
        public void CreateAccount(Account account) => Create(account);
        public void DeleteAccount(Account account) =>
            Delete(account);
        public Account GetAccountByAccountId(Guid accountId, bool trackChangess)=>
            FindByCondition(c=>c.AccountId==accountId,trackChangess).SingleOrDefault();
        public Account GetAccountByUser(string userId, bool trackChangess) =>
            FindByCondition(c => c.UserId == userId, trackChangess).SingleOrDefault();
        public IEnumerable<Account> GetAllAccounts(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Balance).ToList();
    }
}
