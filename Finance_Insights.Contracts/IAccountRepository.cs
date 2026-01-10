using Finance_Insights.Entities.Models;

namespace Finance_Insights.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts(bool trackChanges);
        Account GetAccountByUser(string userId, bool trackChangess);

        Account GetAccountByAccountId(Guid accountId, bool trackChangess);
        void CreateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
