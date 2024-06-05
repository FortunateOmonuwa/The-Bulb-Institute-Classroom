using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Domain.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required!")]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 150 characters")]
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Name")]
        public string Name { get; set; } = "Enter Name";

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is required!")]
        [DataType(DataType.Currency)]
        public string Price { get; set; } = "Price";

        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }

        [ForeignKey(nameof(ExpenseCategory))]
        public int? CategoryId { get; set; }


       // [ForeignKey(nameof(User))]
        public int? UserId { get; set; } 

    }
}
