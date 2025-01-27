using System.Text.Json.Serialization;

namespace CTPortaria.Entities
{
    public class GateLogModel : BaseModel
    {
        public int? EmployeeId { get; set; }
        public EmployeeModel? Employee { get; set; }
        public string? VisitorName { get; set; }
        public string? VisitorIdentity { get; set; }
        public DateTime EnteredAt { get; set; }
        public DateTime? LeavedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public GateLogModel()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
