using MediatR;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Queries
{
    public class OrdersGetQuery : IRequest<IEnumerable<OrderViewModel>>
    {
    }
}
