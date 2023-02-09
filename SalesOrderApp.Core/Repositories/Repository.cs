using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderApp.Persistence.Contexts;

namespace SalesOrderApp.Core.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SalesOrderAppContext _context;
        public Repository(SalesOrderAppContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {

            return _context.Set<T>().Where(filter);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public Task UpdateChildrenAsync<TKey, TForeignKeyValue>(List<T> existingChildrens, List<T> children, TForeignKeyValue foreignKeyValue, string foreignKeyName, string primaryKeyColumn = "Id", TKey defaultPkValue = default(TKey))
        {
            foreach (T item in children)
            {
                TKey getPrimaryKeyValue = (TKey)item.GetType()
                    .GetProperty(primaryKeyColumn)
                    .GetValue(item);
                Func<T, bool> childrenMatchingFilter = x => x.GetType()
                    .GetProperty(primaryKeyColumn)
                    .GetValue(x).Equals(getPrimaryKeyValue);

                if (!existingChildrens.Any(childrenMatchingFilter))
                {
                    item.GetType().GetProperty(foreignKeyName).SetValue(item, foreignKeyValue, null);
                    _context.Add(item);
                }
                else if (children.Any(childrenMatchingFilter))
                {
                    var currentValue = existingChildrens.FirstOrDefault(childrenMatchingFilter);
                    _context.Entry(currentValue).CurrentValues.SetValues(item);
                    _context.Entry(currentValue).Property(foreignKeyName).IsModified = false;
                }
            }
            foreach (var item in existingChildrens)
            {
                TKey getPrimaryKeyValue = (TKey)item.GetType()
                    .GetProperty(primaryKeyColumn)
                    .GetValue(item);
                Func<T, bool> childrenMatchingFilter = x => x.GetType()
                    .GetProperty(primaryKeyColumn)
                    .GetValue(x).Equals(getPrimaryKeyValue);
                if (!children.Any(childrenMatchingFilter))
                {
                    _context.Remove(item);
                }
            }
            return Task.FromResult(Task.CompletedTask);
        }
    }
}
