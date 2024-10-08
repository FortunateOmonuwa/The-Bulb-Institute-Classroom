using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ManagementSystemAPI.Domain.Models
{
    public class Appraisal
    {
        [Key]
        public Guid ID { get; set; }

        [Required, ForeignKey(nameof(Staff))]
        public Guid StaffID { get; set; }

        public DateTime AppraisalDate { get; set; } = DateTime.Now;
        public DateTime AppraisalMonth { get; set; }
        public string EvaluationMessage { get; set; } = "";

    }
}
