using CTPortaria.DTOs;

namespace CTPortaria.Services.Interfaces
{

    public interface IEmployeeService
    {
        Task<EmployeeCreateDto> CreateAsync(EmployeeCreateDto employeeCreateDto);
    }
}
