using Finance_Insights.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Insights.Repository
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
    }
}
