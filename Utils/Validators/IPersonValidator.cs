namespace CTPortaria.Utils.Validators
{
    public interface IPersonValidator
    {
        bool ValidateName(string name);
        bool ValidateCpf(string cpf);
        bool ValidateJobRole(string jobRole);
        string CleanCpf(string cpf);
    }
}
