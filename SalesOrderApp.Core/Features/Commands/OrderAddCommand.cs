using System;
using MediatR;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Commands
{
	public class OrderAddCommand : OrderRequestViewModel, IRequest<bool>
    {
       
    }
}

