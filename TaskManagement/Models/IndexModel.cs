using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagement.Models;
using TaskManagement.Repositories;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement.Models
{
    public class IndexModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;

        public IndexModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IList<TaskItem> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            Tasks = (await _taskRepository.GetTasksAsync()).ToList();
        }
    }
}
