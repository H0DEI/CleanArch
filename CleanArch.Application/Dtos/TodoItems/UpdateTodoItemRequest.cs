namespace CleanArch.Application.Dtos.TodoItems;

public class UpdateTodoItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
