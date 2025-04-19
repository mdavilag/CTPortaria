namespace CTPortaria.DTOs
{
    public class GateLogCreateResultDTO
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? VisitorId { get; set; }
        public DateTime EnteredAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RegisteredBy { get; set; }
        public string Description { get; set; }
    }
}
