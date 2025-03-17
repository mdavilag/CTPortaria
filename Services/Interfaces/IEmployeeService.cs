using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Services.Interfaces
{

    public interface IEmployeeService
    {
        Task<EmployeeServiceDTO> GetByNameAsync(string name);
        Task<IList<EmployeeServiceDTO>> GetAllAsync();
        Task<EmployeeServiceDTO> GetByIdAsync(int id);
        Task<EmployeeServiceDTO> CreateAsync(EmployeeCreateDto employeeCreateDto);
        Task<EmployeeServiceDTO> UpdateAsync(int it, EmployeeUpdateDTO employeeUpdateDto);
        Task<bool> DeleteByIdAsync(int id);
        EmployeeServiceDTO MapEmployeeToDto(EmployeeModel employeeModel);
        EmployeeModel MapCreateDtoToEmployeeModel(EmployeeCreateDto employeeDto);

    }
}
