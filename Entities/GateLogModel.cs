namespace CTPortaria.Entities
{
    public class GateLogModel : BaseModel
    {
        public int? EmployeeId { get; set; }
        public EmployeeModel? Employee { get; set; }
        public string? VisitorName { get; set; }
        public string? VisitorDocument { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public DateTime CreatedAt { get; set; }

        public GateLogModel()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
