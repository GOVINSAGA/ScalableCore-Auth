using System.ComponentModel.DataAnnotations;

namespace BackendAPI.DTOs;

public class CreateTaskDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
}