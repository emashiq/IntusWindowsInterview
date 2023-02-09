using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Commands.Handlers
{
    public class OrderUpdateHandler : IRequestHandler<OrderUpdateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
                var dbSet = _unitOfWork.Repository<Order>();
                var order = await dbSet.Get(x => x.Id == request.Id)
                    .Include(x => x.Windows)
                    .ThenInclude(x => x.SubElements)
                    .FirstOrDefaultAsync();

                if (order != null)
                {
                    var orderRequest = _mapper.Map<Order>(request);
                    await _unitOfWork.Repository<Window>().UpdateChildrenAsync<int, int>(order.Windows, orderRequest.Windows, request.Id ?? 0, "OrderId");
                    foreach (var item in orderRequest.Windows)
                    {
                        if (item.Id == 0)
                            continue;
                        await _unitOfWork.Repository<SubElement>().UpdateChildrenAsync<int, int>(order.Windows.FirstOrDefault(x=>x.Id == item.Id).SubElements, item.SubElements ?? new(), item.Id, "WindowId");
                    }

                    order.Name = request.Name;
                    order.State = request.State;
                    dbSet.Update(order);

                    return await _unitOfWork.SaveChangeAsync() > 0;
                }
                return false;
        }
    }
}

