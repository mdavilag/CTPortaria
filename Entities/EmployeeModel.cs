﻿using System.Text.Json.Serialization;

namespace CTPortaria.Entities
{
    public class EmployeeModel : PersonModel
    {
        // public string Name { get; set; }
        // public string Cpf { get; set; }
        public string JobRole { get; set; }
        public bool IsActive { get; set; } = true;

        [JsonIgnore] public List<GateLogModel> GateLogs { get; set; } = new List<GateLogModel>();
    }
}
