using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Services.Shared;

namespace CTPortaria.Services.Interfaces
{

    public interface IEmployeeService
    {
        Task<ResultService<EmployeeServiceDTO>> GetByNameAsync(string name);
        Task<ResultService<List<EmployeeServiceDTO>>> GetAllAsync();
        Task<ResultService<EmployeeServiceDTO>> GetByIdAsync(int id);
        Task<ResultService<EmployeeServiceDTO>> CreateAsync(EmployeeCreateDto employeeCreateDto);
        Task<ResultService<EmployeeServiceDTO>> UpdateAsync(int it, EmployeeUpdateDTO employeeUpdateDto);
        Task<ResultService<bool>> DeleteByIdAsync(int id);
        EmployeeServiceDTO MapEmployeeToDto(EmployeeModel employeeModel);
        EmployeeModel MapCreateDtoToEmployeeModel(EmployeeCreateDto employeeDto);

    }
}
