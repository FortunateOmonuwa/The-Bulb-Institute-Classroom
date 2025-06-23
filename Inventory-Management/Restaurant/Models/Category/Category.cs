using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.Category
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "non specified";
    }
}
