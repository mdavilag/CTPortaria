namespace CTPortaria.Entities
{
    public class PackageModel : BaseModel
    {
        public string Description { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
