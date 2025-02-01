using System.Text.RegularExpressions;

namespace CTPortaria.Utils.Validators
{
    public class EmployeeValidator : IEmployeeValidator
    {
        public bool ValidateName(string name)
        {
            if(name.Length <= 3) return false;
            if (Regex.IsMatch(name, ".*\\d.*")) return false;
            return true;
        }

        public bool ValidateCpf(string cpf)
        {
            if (cpf.Length != 11) return false;
            if (Regex.IsMatch(cpf, "^\\d{11}$")) return true;
            return false;
        }

        public bool ValidateJobRole(string jobRole)
        {
            if (jobRole.Length <= 3) return false;
            if (Regex.IsMatch(jobRole, ".*\\d.*")) return false;
            return true;
        }
    }
}
