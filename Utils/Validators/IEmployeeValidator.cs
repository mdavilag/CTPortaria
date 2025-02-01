namespace CTPortaria.Utils.Validators
{
    public interface IEmployeeValidator
    {
        bool ValidateName(string name);
        bool ValidateCpf(string cpf);
        bool ValidateJobRole(string jobRole);
    }
}
