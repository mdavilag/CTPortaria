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
    }
}
