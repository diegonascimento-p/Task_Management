using TaskManagement.Models;

namespace TaskManagement.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}
