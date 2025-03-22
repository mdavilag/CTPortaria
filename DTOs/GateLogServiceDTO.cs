using Newtonsoft.Json;

namespace CTPortaria.DTOs
{
    public class GateLogServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public string PersonType { get; set; } // employee or visitor (change to Enum)

        public DateTime EnteredAt { get; set; }
        public DateTime? LeavedAt { get; set; }

        public string RegisteredBy { get; set; }
        public string Description { get; set; }
    }
}
