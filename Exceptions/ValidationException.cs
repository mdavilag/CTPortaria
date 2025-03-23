namespace CTPortaria.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; } = new List<string>();
        public ValidationException(List<string> errors) : base("Erro de validação")
        {
            Errors = errors;
        }

        public ValidationException(string error) : base("Erro de validação")
        {
            Errors.Add(error);
        }
    }
}
