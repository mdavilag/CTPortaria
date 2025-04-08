using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CTPortaria.Utils.Validators
{
    public class PersonValidator : IPersonValidator
    {
        public bool ValidateName(string name)
        {
            if(name.Length <= 3) return false;
            if (Regex.IsMatch(name, ".*\\d.*")) return false;
            return true;
        }

        public bool ValidateCpf(string cpf)
        {
            var cleanedCpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cleanedCpf.Length != 11) return false;
            if (Regex.IsMatch(cleanedCpf, "^\\d{11}$")) return true;
            return false;
        }

        public bool ValidateJobRole(string jobRole)
        {
            if (jobRole.Length <= 3) return false;
            if (Regex.IsMatch(jobRole, ".*\\d.*")) return false;
            return true;
        }

        public string CleanCpf(string cpf)
        {
            return cpf.Trim().Replace("-", "").Replace(".", "");
        }

        public bool ValidateId(int id)
        {
            if (id < 0) return false;
            return true;
        }
    }
}
