using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _context.TaskItems.Include(t => t.User).ToListAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.TaskItems.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
