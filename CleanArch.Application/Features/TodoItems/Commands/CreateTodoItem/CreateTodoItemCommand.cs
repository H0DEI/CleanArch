using CleanArch.Application.Dtos.TodoItems;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand(string Title, string? Description)
    : IRequest<TodoItemDto>;
