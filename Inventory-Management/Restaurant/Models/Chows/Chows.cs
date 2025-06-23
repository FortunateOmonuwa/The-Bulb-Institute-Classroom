using Restaurant.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.Chows
{
    public class Chows
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsChowOfTheWeek { get; set; }
        public bool InStock { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public HealthStatus HealthStatus { get; set; }
    }
}
