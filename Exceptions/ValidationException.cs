namespace CTPortaria.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException(List<string> errors) : base("Erro de validação")
        {
            Errors = errors;
        }
    }
}
