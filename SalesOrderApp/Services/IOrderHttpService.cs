using System;
namespace SalesOrderApp.Services
{
	public interface IOrderHttpService
	{
        Task<bool> AddAsync(Order order);
        Task<bool> EditAsync(Order order);
        Task<bool> GetAsync();
        Task<bool> GetAsync(int? id);
        Task<bool> DeleteAsync(int? id);
    }
}

