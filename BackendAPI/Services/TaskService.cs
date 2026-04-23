using BackendAPI.DTOs;
using BackendAPI.Models;
using BackendAPI.Repositories;

namespace BackendAPI.Services;

public class TaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    // 👤 USER: Get own tasks
    public async Task<List<TaskResponseDto>> GetTasks(int userId)
    {
        var tasks = await _repo.GetByUserId(userId);

        return tasks.Select(t => new TaskResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description
        }).ToList();
    }

    // 👑 ADMIN: Get all tasks
    public async Task<List<TaskResponseDto>> GetAllTasks()
    {
        var tasks = await _repo.GetAll();

        return tasks.Select(t => new TaskResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description
        }).ToList();
    }

    // ➕ CREATE (both roles)
    public async Task<TaskResponseDto> Create(int userId, CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            UserId = userId
        };

        await _repo.Add(task);

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };
    }

    // 👤 USER: Delete own task
    public async Task<string> Delete(int id, int userId)
    {
        var task = await _repo.GetById(id);

        if (task == null || task.UserId != userId)
            throw new Exception("Task not found");

        await _repo.Delete(task);

        return "Deleted successfully";
    }

    // 👑 ADMIN: Delete any task
    public async Task<string> DeleteAsAdmin(int id)
    {
        var task = await _repo.GetById(id);

        if (task == null)
            throw new Exception("Task not found");

        await _repo.Delete(task);

        return "Deleted successfully (Admin)";
    }

    // 👤 USER: Update own task
    public async Task<TaskResponseDto> Update(int id, int userId, UpdateTaskDto dto)
    {
        var task = await _repo.GetById(id);

        if (task == null || task.UserId != userId)
            throw new Exception("Task not found");

        task.Title = dto.Title;
        task.Description = dto.Description;

        await _repo.Update(task);

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };
    }

    // 👑 ADMIN: Update any task
    public async Task<TaskResponseDto> UpdateAsAdmin(int id, UpdateTaskDto dto)
    {
        var task = await _repo.GetById(id);

        if (task == null)
            throw new Exception("Task not found");

        task.Title = dto.Title;
        task.Description = dto.Description;

        await _repo.Update(task);

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };
    }
}