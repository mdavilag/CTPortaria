﻿using CTPortaria.Entities;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IGateLogRepository
    {
        Task<List<GateLogModel>> GetAllAsync();
        Task<GateLogModel> GetByIdAsync(int id);
        Task<List<GateLogModel>> GetByDayAsync(DateTime date);
        Task<List<GateLogModel>> GetByDateTimeAsync(DateTime initDate, DateTime endDate);
        Task<List<GateLogModel>> GetByEmployeeAsync(EmployeeModel employee);
        Task<List<GateLogModel>> GetByVisitorNameAsync(string visitorName);

        // Create
        // Update
        // Delete
        
    }
}
