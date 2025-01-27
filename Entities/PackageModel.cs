namespace CTPortaria.Entities
{
    public class PackageModel : BaseModel
    {
        public string Description { get; set; } 
        public string ReceivedBy { get; set; } // GateKepper who got the package
        public string AdressedTo { get; set; } // Person who need to receive the package
        public string ToSector { get; set; } // Company Sector
        public string? DeliveredTo { get; set; } // Person who received the package by the Gatekeeper
        public DateTime? DeliveredAt { get; set; } // Time that the package was delivery to the person Adressed
        public DateTime ReceivedAt { get; set; } // Time when the package was received by the GateKeeper
    }
}
