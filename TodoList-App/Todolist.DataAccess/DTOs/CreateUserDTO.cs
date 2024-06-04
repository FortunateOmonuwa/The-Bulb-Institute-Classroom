using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.Domain.Models;

namespace Todolist.Domain.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<TodoItem>? Tasks { get; set; }
    }
}
