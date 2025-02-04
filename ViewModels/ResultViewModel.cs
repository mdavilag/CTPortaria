namespace CTPortaria.ViewModels
{
    public class ResultViewModel<T>
    {
        public bool IsSucess { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResultViewModel(T data)
        {
            IsSucess = true;
            Data = data;
        }

        public ResultViewModel(List<string> errors)
        {
            IsSucess = false;
            Errors = errors;
        }

        public ResultViewModel(string error)
        {
            IsSucess = false;
            Errors.Add(error);
        }
    }
}
