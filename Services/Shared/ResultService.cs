namespace CTPortaria.Services.Shared
{
    public class ResultService<T>
    {
        public bool IsSucess { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResultService(T data)
        {
            IsSucess = true;
            Data = data;
        }

        public ResultService(List<string> errors)
        {
            IsSucess = false;
            Errors = errors;
        }

        public ResultService(string error)
        {
            IsSucess = false;
            Errors.Add(error);
        }
    }
}
