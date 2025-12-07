using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Queries.GetTodoItems;

public class GetTodoItemsQueryHandler
    : IRequestHandler<GetTodoItemsQuery, List<TodoItemDto>>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemsQueryHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<List<TodoItemDto>> Handle(
        GetTodoItemsQuery request,
        CancellationToken cancellationToken)
    {
        var items = await _todoItemRepository.GetAllAsync(cancellationToken);
        return items.Select(i => i.ToDto()).ToList();
    }
}
