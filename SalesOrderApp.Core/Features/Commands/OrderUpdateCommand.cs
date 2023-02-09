using System;
using MediatR;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Commands
{
	public class OrderUpdateCommand : OrderRequestViewModel, IRequest<bool>
    {
	}
}

