using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Enums;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IGateLogRepository
    {
        Task<List<GateLogModel>> GetAllAsync();
        Task<List<GateLogModel>> GetAllInsideAsync();
        Task<GateLogModel> GetByIdAsync(int id);
        Task<List<GateLogModel>> GetByDayAsync(DateTime date);
        Task<List<GateLogModel>> GetByEmployeeAsync(int id);
        Task<List<GateLogModel>> SearchQueryAsync(GateLogSearchDTO searchQuery);
        Task<bool> IsPersonInside(EPersonType personType, int id);

        // Create
        Task<GateLogModel> CreateAsync(GateLogModel gateLogToCreate);

        // Update
        Task<GateLogModel> UpdateAsync(GateLogModel gateLogToUpdate);

        // Delete

        Task<bool> DeleteByIdAsync(int id);

    }
}
