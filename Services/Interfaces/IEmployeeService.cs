using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Services.Interfaces
{

    public interface IEmployeeService
    {
        Task<EmployeeServiceDTO> GetByNameAsync(string name);
        Task<List<EmployeeServiceDTO>> GetAllAsync();
        Task<EmployeeServiceDTO> GetByIdAsync(int id);
        Task<EmployeeCreateDto> CreateAsync(EmployeeCreateDto employeeCreateDto);
        Task<EmployeeServiceDTO> UpdateAsync(EmployeeServiceDTO employeeServiceDTO);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> ExistsById(int id);

    }
}
