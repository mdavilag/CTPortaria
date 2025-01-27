namespace CTPortaria.Entities
{
    public class EmployeeModel : BaseModel
    {
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string JobPosition { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
