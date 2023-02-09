using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Commands.Handlers
{
	public class OrderDeleteHandler :IRequestHandler<OrderDeleteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDeleteHandler (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var dbSet =_unitOfWork.Repository<Order>();
            var order = await dbSet.Get(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            if (order != null)
            {
                dbSet.Delete(order);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            return false;
        }
    }
}

