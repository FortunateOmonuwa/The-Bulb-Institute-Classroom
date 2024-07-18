using OrganizationMgtSys.Domain.Models.Generic_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationMgtSys.Domain.Models
{
    public class Appraisal : GenericProps
    {
        public DateTime AppraisalDate {  get; set; } = DateTime.Now.Date;
        public DateTime AppraisalMonth { get; set; } = DateTime.Now;
        [ForeignKey(nameof(Staff))]
        public Guid StaffId { get; set; }
        public string EvaluationMessage { get; set; }
    }
}