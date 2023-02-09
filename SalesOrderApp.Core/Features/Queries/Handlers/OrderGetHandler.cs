using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Queries.Handlers
{
	public class OrderGetHandler:IRequestHandler<OrderGetQuery, Order>
	{
        private readonly IUnitOfWork _unitOfWork;
        public OrderGetHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Handle(OrderGetQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Order>().Get().Include(x=>x.Windows).ThenInclude(x=>x.SubElements).FirstOrDefaultAsync(x=>x.Id==request.Id);
        }
    }
}

