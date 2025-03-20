using System.Text.Json.Serialization;

namespace CTPortaria.Entities
{
    public class GateLogModel : BaseModel
    {
        public int? EmployeeId { get; set; }
        public EmployeeModel? Employee { get; set; }
        public int? VisitorId { get; set; }
        public VisitorModel? Visitor { get; set; }
        public DateTime EnteredAt { get; set; }
        public DateTime? LeavedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RegisteredBy { get; set; }
        public string Description { get; set; }

    }
}
