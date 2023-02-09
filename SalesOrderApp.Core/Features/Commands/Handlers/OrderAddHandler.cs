using System;
using AutoMapper;
using MediatR;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Commands.Handlers
{
	public class OrderAddHandler : IRequestHandler<OrderAddCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderAddHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            _unitOfWork.Repository<Order>().Add(order);
            return await _unitOfWork.SaveChangeAsync() > 0;

        }
    }
}

