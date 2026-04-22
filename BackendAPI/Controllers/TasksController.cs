using BackendAPI.DTOs;
using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/v1/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;

    public TasksController(TaskService service)
    {
        _service = service;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var result = await _service.GetTasks(GetUserId());
        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Tasks fetched successfully",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var result = await _service.Create(GetUserId(), dto);
        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Tasks created successfully",
            Data = result
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id, GetUserId());
        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Tasks deleted successfully",
            Data = result
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var result = await _service.Update(id, GetUserId(), dto);
        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Tasks updated successfully",
            Data = result
        });
    }
}