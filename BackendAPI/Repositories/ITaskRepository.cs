// Repositories/ITaskRepository.cs
using BackendAPI.Models;

namespace BackendAPI.Repositories;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetByUserId(int userId);
    Task<TaskItem> GetById(int id);
    Task Add(TaskItem task);
    Task Update(TaskItem task);
    Task Delete(TaskItem task);

    Task<List<TaskItem>> GetAll();
}