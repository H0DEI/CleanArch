namespace CleanArch.Application.Dtos.TodoItems;

public class CreateTodoItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
