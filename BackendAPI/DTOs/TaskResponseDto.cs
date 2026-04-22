// DTOs/TaskResponseDto.cs
namespace BackendAPI.DTOs;

public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}