using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TaskManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TaskItem> Tasks { get; set; }
    }
}