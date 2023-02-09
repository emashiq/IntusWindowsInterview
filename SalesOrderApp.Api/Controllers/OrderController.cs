using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesOrderApp.Core.Features.Commands;
using SalesOrderApp.Core.Features.Queries;
using System.Net;

namespace SalesOrderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var res = await _mediator.Send(new OrdersGetQuery
            {
            });

            return StatusCode(res == null ? StatusCodes.Status406NotAcceptable : StatusCodes.Status200OK, res);
        }
        [HttpGet]
        [Route("get-order/{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var res = await _mediator.Send(new OrderGetQuery {
                Id = id
            });

            return StatusCode(res==null? StatusCodes.Status406NotAcceptable:StatusCodes.Status200OK,res);
        }

        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderAddCommand order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _mediator.Send(order);
            return StatusCode(res?StatusCodes.Status200OK: StatusCodes.Status406NotAcceptable, res);
        }

        [HttpPut]
        [Route("update-order/{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] OrderUpdateCommand order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _mediator.Send(order);
            return StatusCode(res ? StatusCodes.Status200OK : StatusCodes.Status406NotAcceptable, res);
        }

        [HttpDelete]
        [Route("remove-order/{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var res = await _mediator.Send(new OrderDeleteCommand
            {
                Id = id
            });
            return StatusCode(res ? StatusCodes.Status200OK : StatusCodes.Status406NotAcceptable, res);
        }

    }
}
