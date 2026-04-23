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

    private string GetUserRole()
    {
        return User.FindFirst(ClaimTypes.Role)?.Value;
    }

    // ✅ GET TASKS (Role-based)
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var role = GetUserRole();

        var result = role == "Admin"
            ? await _service.GetAllTasks()        // 👑 Admin sees all
            : await _service.GetTasks(GetUserId()); // 👤 User sees own

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Tasks fetched successfully",
            Data = result
        });
    }

    // ✅ CREATE TASK (Both roles)
    [Authorize(Roles = "User,Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var result = await _service.Create(GetUserId(), dto);

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Task created successfully",
            Data = result
        });
    }

    // ✅ DELETE TASK (Admin OR Owner)
    [Authorize(Roles = "User,Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var role = GetUserRole();

        var result = role == "Admin"
            ? await _service.DeleteAsAdmin(id)         // 👑 Admin can delete any
            : await _service.Delete(id, GetUserId());  // 👤 User only own

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Task deleted successfully",
            Data = result
        });
    }

    // ✅ UPDATE TASK (Admin OR Owner)
    [Authorize(Roles = "User,Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var role = GetUserRole();

        var result = role == "Admin"
            ? await _service.UpdateAsAdmin(id, dto)        // 👑 Admin update any
            : await _service.Update(id, GetUserId(), dto); // 👤 User only own

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Task updated successfully",
            Data = result
        });
    }
}