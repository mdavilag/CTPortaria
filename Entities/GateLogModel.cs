namespace CTPortaria.Entities
{
    public class GateLogModel : BaseModel
    {
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
    }
}
