using AutoMapper;
using Finance_Insights.Contracts;
using Finance_Insights.Entities.Models;
using Finance_Insights.Service_Contracts;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
        {
            this._repository = repository;
            this._logger = loggerManager;
            this._mapper = mapper;
        }
        public Account CreateAccount(AccountForCreationDto account,bool trackChanges)
        {
            var accountEntity = _repository.accountRepository.GetAccountByUser(account.UserId, trackChanges);
            if (accountEntity == null)
            {
                accountEntity=_mapper.Map<Account>(account);
                _repository.accountRepository.CreateAccount(accountEntity);
                _repository.Save();
                return accountEntity;
            }
            else
            {
                throw new InvalidOperationException("Account already exists for this account");
            }
        }

        public void DeleteAccount(Guid accountId, bool trackChanges)
        {
            var account=_repository.accountRepository.GetAccountByAccountId(accountId,trackChanges);
            if(account == null)
            {
                throw new InvalidOperationException("Account does not exitst");
            }
            _repository.accountRepository.DeleteAccount(account);
            _repository.Save();
        }

        public Account GetAccountByAccountId(Guid accountId, bool trackChanges)
        {
            var account=_repository.accountRepository.GetAccountByAccountId(accountId, trackChanges);
            if (account == null)
            {
                throw new InvalidOperationException("Account Does not exist");
            }
            return account;
        }

        public Account GetAccountByUserId(string userId, bool trackChanges)
        {
            var account=_repository.accountRepository.GetAccountByUser(userId,trackChanges);
            if (account == null)
            {
                throw new InvalidOperationException("Account does not exitst");
            }
            return account;
        }
        public IEnumerable<Account> GetAllAccounts(bool trackChanges)
        {
            return _repository.accountRepository.GetAllAccounts(trackChanges);
        }

        public (AccountForUpdateDto accountToPatch, Account accountEntity) GetAccountforPatch(string userId, bool trackChanges)
        {
            var account= _repository.accountRepository.GetAccountByUser(userId, trackChanges);
            if(account is null)
            {
                throw new InvalidOperationException("account does not exist");
            }
            var accountToPatch=_mapper.Map<AccountForUpdateDto>(account);
            return(accountToPatch, account);
        }
        public void SaveChangesForPatch(AccountForUpdateDto accountForUpdateDto, Account accountEntity)
        {
            _mapper.Map(accountForUpdateDto, accountEntity);
            _repository.Save();
        }
    }
}
