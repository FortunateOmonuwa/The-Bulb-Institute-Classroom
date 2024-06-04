using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.Text), Length(3, 20)]        
        public string Name { get; set; } = string.Empty;
        public List<TodoItem>? Tasks { get; set; }
    }
}
