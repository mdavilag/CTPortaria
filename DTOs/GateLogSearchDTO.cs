using CTPortaria.Enums;

namespace CTPortaria.DTOs
{
    public class GateLogSearchDTO
    {
        public DateTime? InitDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public EPersonType? PersonType { get; set; }
    }
}
