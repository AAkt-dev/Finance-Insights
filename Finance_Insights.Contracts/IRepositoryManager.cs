using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Insights.Contracts
{
    public interface IRepositoryManager
    {
        IAccountRepository accountRepository { get; }
        ICategoryRepository categoryRepository { get; }
        void Save();
    }
}
