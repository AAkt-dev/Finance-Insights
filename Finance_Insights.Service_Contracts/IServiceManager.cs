namespace Finance_Insights.Service_Contracts
{
    public interface IServiceManager
    {
        IAccountService accountService { get; }

        ICategoryService categoryService { get; }
    }
}
