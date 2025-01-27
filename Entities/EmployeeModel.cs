namespace CTPortaria.Entities
{
    public class EmployeeModel : BaseModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string JobRole { get; set; }
        public bool IsActive { get; set; } = true;
        public List<GateLogModel> GateLogs { get; set; }
    }
}
