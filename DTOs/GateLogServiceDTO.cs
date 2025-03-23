using CTPortaria.Enums;
using Newtonsoft.Json;

namespace CTPortaria.DTOs
{
    public class GateLogServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } // Employee or Visitor name
        public string Cpf { get; set; } // Employee Or Visitor CPF

        public string PersonType { get; set; }

        public DateTime EnteredAt { get; set; }
        public DateTime? LeavedAt { get; set; }

        public string RegisteredBy { get; set; }
        public string Description { get; set; }
    }
}
