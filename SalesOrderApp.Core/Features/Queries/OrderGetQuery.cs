using System;
using MediatR;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Features.Queries
{
	public class OrderGetQuery:IRequest<Order>
	{
		public int Id { get; set; }
	}
}

