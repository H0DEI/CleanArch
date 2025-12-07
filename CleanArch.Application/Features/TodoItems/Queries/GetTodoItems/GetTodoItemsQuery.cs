using CleanArch.Application.Dtos.TodoItems;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Queries.GetTodoItems;

public record GetTodoItemsQuery : IRequest<List<TodoItemDto>>;
