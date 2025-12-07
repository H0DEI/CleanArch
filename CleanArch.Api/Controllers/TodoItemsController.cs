using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Features.TodoItems.Commands.CreateTodoItem;
using CleanArch.Application.Features.TodoItems.Queries.GetTodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/todoitems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoItemsQuery(), cancellationToken);
        return Ok(result);
    }

    // POST: api/todoitems
    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(
        [FromBody] CreateTodoItemRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateTodoItemCommand(request.Title, request.Description);
        var dto = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetAll), // provisional, luego cambiaremos a GetById cuando lo tengamos
            new { id = dto.Id },
            dto);
    }
}
