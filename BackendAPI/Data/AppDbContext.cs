// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

namespace BackendAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
}