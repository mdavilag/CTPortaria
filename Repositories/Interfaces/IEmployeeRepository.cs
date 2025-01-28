using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> GetByNameAsync(string name);
        Task<List<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetByIdAsync(int id);
        Task<EmployeeModel> CreateAsync(EmployeeCreateDto employeeToCreate);
        Task<EmployeeModel> UpdateAsync();
        Task<EmployeeModel> DeleteAsync();
    }
}
