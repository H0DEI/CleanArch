using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandHandler
    : IRequestHandler<CreateTodoItemCommand, TodoItemDto>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItemDto> Handle(
        CreateTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            Description = request.Description
        };

        await _todoItemRepository.AddAsync(entity, cancellationToken);

        return entity.ToDto();
    }
}
