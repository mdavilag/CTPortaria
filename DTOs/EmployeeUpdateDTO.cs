namespace CTPortaria.DTOs
{
    public class EmployeeUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string JobRole { get; set; }
        public bool IsActive { get; set; }
    }
}
