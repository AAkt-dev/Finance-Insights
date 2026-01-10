using Finance_Insights.Entities.Models;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.Service_Contracts
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts(bool trackChanges);
        Account GetAccountByUserId(string userId,bool trackChanges);
        Account GetAccountByAccountId(Guid accountId,bool trackChanges);
        (AccountForUpdateDto accountToPatch,Account accountEntity) GetAccountforPatch(string userId,bool trackChanges);
        void SaveChangesForPatch(AccountForUpdateDto accountForUpdateDto, Account accountEntity);
        Account CreateAccount(AccountForCreationDto account,bool trackChanges);
        void DeleteAccount(Guid accountId, bool trackChanges);
    }
}
