namespace CTPortaria.Entities
{
    public class VehicleModel : BaseModel
    {
        public string CompanyName { get; set; }
        public string Invoice { get; set; } // Nota Fiscal
        public string DriversName { get; set; }
        public string DriversIdentity { get; set; } // Driver's document
        public string LicensePlate { get; set; }
        public string CarModel { get; set; }
        public string ToSector { get; set; } // Company Sector
        public string Category { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime ArrivedAt { get; set; }
        public DateTime LeavedAt { get; set; }
    }
}
// DATA	NOME DA EMPRESA	Nº NOTA FISCAL	NOME DO MOTORISTA
// Nº IDENTIDADE	PLACA VEÍCULO	SETOR/DESTINO	DESCRIMINAÇÃO
// HORA ENTR.	HORA SAÍDA	RECEBIDO POR