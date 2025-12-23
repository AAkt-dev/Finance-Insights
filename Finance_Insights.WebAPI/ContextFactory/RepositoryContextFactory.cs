using Finance_Insights.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Finance_Insights.WebAPI.ContextFactory
{
    public class RepositoryContextFactory:IDesignTimeDbContextFactory<RepositoryContext>
    {
       public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder= new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(configuration.GetConnectionString("Finance"),
                b=>b.MigrationsAssembly("Finance_Insights.WebAPI"));
            return new RepositoryContext(builder.Options);
        }
    }
}
