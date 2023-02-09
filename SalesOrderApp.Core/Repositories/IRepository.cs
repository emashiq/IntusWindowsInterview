using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Core.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Find(object id);
        IQueryable<T> Get(Expression<Func<T,bool>> filter);
        IQueryable<T> Get();

        Task UpdateChildrenAsync<TKey, TForeignKeyValue>(List<T> existingChildrens, List<T> children,TForeignKeyValue foreignKeyValue, string foreignKeyName, string primaryKeyColumn = "Id", TKey defaultPkValue = default(TKey));
    }
}
