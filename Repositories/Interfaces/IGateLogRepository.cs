using CTPortaria.Entities;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IGateLogRepository
    {
        Task<List<GateLogModel>> GetAllAsync();
        Task<List<GateLogModel>> GetAllInsideAsync();
        Task<GateLogModel> GetByIdAsync(int id);
        Task<List<GateLogModel>> GetByDayAsync(DateTime date);
        Task<List<GateLogModel>> GetByDateTimeAsync(DateTime initDate, DateTime endDate);
        Task<List<GateLogModel>> GetByEmployeeAsync(int id);
        Task<List<GateLogModel>> GetByVisitorIdentity(string visitorIdentity);

        // Create
        Task<GateLogModel> CreateAsync(GateLogModel gateLogToCreate);

        // Update
        Task<GateLogModel> UpdateAsync(GateLogModel gateLogToUpdate);

        // Delete

        Task<bool> DeleteByIdAsync(int id);

    }
}
