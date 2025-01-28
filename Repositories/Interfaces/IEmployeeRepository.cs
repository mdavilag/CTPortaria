using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> GetByNameAsync(string name);
        Task<List<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetByIdAsync(int id);
        Task<EmployeeModel> CreateAsync(EmployeeModel employeeToCreate);
        Task<EmployeeModel> UpdateAsync(EmployeeModel employeeToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
