using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Queries.Handlers
{
	public class OrdersGetHandler:IRequestHandler<OrdersGetQuery, IEnumerable<OrderViewModel>>
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrdersGetHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderViewModel>> Handle(OrdersGetQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().Get().Include(x=>x.Windows).ThenInclude(x=>x.SubElements).ToListAsync();
            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }
    }
}

