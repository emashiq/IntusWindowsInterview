using System;
using MediatR;

namespace SalesOrderApp.Core.Features.Commands
{
	public class OrderDeleteCommand:IRequest<bool>
	{
		public int Id { get; set; }
	}
}

