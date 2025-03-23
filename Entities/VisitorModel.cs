namespace CTPortaria.Entities
{
    public class VisitorModel : PersonModel
    {
        // public string Name { get; set; }
        // public string Cpf { get; set; }

        public string CompanyName { get; set; }

        public List<GateLogModel> GateLogs { get; set; } = new List<GateLogModel>();
    }
}
