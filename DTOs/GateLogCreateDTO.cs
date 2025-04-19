namespace CTPortaria.DTOs
{
    public class GateLogCreateDTO
    {
        public int? EmployeeId { get; set; }
        public int? VisitorId { get; set; }
        public DateTime EnteredAt { get; set; }
        public string RegisteredBy { get; set; }
        public string Description { get; set; }

    }
}
