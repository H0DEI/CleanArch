using CleanArch.Domain.Entities;

namespace CleanArch.Application.Dtos.TodoItems;

public static class TodoItemMappings
{
    public static TodoItemDto ToDto(this TodoItem entity)
    {
        return new TodoItemDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            IsCompleted = entity.IsCompleted,
            CreatedAt = entity.CreatedAt
        };
    }
}
