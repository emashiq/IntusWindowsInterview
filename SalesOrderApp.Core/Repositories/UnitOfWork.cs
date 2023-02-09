using SalesOrderApp.Persistence.Contexts;

namespace SalesOrderApp.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesOrderAppContext _context;
        private readonly Dictionary<Type, object> _repositories;
        public UnitOfWork(SalesOrderAppContext context)
        {
            _context = context;
            _repositories = new();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(IRepository<T>);
            if (!_repositories.ContainsKey(type))
                _repositories.Add(type, new Repository<T>(_context));
            return (IRepository<T>)_repositories[type];
        }

        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
        public int SaveChange() => _context.SaveChanges();
    }
}
