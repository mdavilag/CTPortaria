using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Services.Interfaces
{
    public interface IGateLogService
    {
        Task<List<GateLogServiceDTO>> GetAllAsync();
        Task<List<GateLogServiceDTO>> GetAllInsideAsync();

        Task<GateLogServiceDTO> GetByIdAsync(int id);
        Task<List<GateLogServiceDTO>> GetByDayAsync(DateTime date);
        Task<List<GateLogServiceDTO>> GetByDateTimeAsync(DateTime initDate, DateTime endDate);
        Task<List<GateLogServiceDTO>> GetByEmployeeAsync(int id);
        Task<List<GateLogServiceDTO>> GetByPersonCpfAsync(string visitorCpf);

        Task<List<GateLogServiceDTO>> SearchQueryAsync(GateLogSearchDTO searchQuery);

        // Create
        // Task<GateLogServiceDTO> CreateAsync(GateLogModel gateLogToCreate) -> Falta criar create/updateDTO

        // Update
        // Task<GateLogServiceDTO> UpdateAsync(); -> Falta criar create/updateDTO
        Task<GateLogServiceDTO> RegisterExitAsync(int gateLogId);

        // Delete

        Task<bool> DeleteByIdAsync(int id);
    }
}
