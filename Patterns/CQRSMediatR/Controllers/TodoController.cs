using MediatR;
using MediatRExample.Commands;
using MediatRExample.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRExample.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTOdoById(int id)
        {
            var response = await mediator.Send(new GetTodoById.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTodo(AddTodo.Command command) => Ok(await mediator.Send(command));
    }
}
