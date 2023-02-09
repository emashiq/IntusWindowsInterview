namespace SalesOrderApp.Core.Repositories
{
    public interface IUnitOfWork
    {
        public int SaveChange();
        Task<int> SaveChangeAsync();
        public IRepository<T> Repository<T>() where T : class;
    }
}
