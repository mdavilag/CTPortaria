using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Repositories.Interfaces;
using CTPortaria.Services.Interfaces;
using CTPortaria.Services.Shared;
using CTPortaria.Utils.Validators;

namespace CTPortaria.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeValidator _validator;

        public EmployeeService(IEmployeeRepository repository, IEmployeeValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ResultService<EmployeeServiceDTO>> GetByNameAsync(string name)
        {
            if (_validator.ValidateName(name) == false)
            {
                return new ResultService<EmployeeServiceDTO>("Nome não é válido, digite o nome completo");
            }
            
            var employee = await _repository.GetByNameAsync(name);
            if (employee == null)
            {
                return new ResultService<EmployeeServiceDTO>("Erro ao localizar usuário");
            }
                // Mapear o model para o DTO

            var employeeDto = MapEmployeeToDto(employee);

            return new ResultService<EmployeeServiceDTO>(employeeDto);
        }

        public async Task<ResultService<List<EmployeeServiceDTO>>> GetAllAsync()
        {
            try
            {
                var employees = await _repository.GetAllAsync();

                var employeeDtos = employees
                    .Select(employee => new EmployeeServiceDTO()
                {
                    Name = employee.Name,
                    Cpf = employee.Cpf,
                    JobRole = employee.JobRole,
                    IsActive = employee.IsActive
                });

                return new ResultService<List<EmployeeServiceDTO>>(employeeDtos.ToList());
            }
            catch(Exception ex)
            {
                return new ResultService<List<EmployeeServiceDTO>>(ex.Message);
            }
        }

        public async Task<ResultService<EmployeeServiceDTO>> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return new ResultService<EmployeeServiceDTO>("Usuário não encontrado");
            }

            var employeeDto = MapEmployeeToDto(employee);

            return new ResultService<EmployeeServiceDTO>(employeeDto);
        }

        public async Task<ResultService<EmployeeServiceDTO>> CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            // Validate Properties
            if (!_validator.ValidateName(employeeCreateDto.Name))
            {
                return new ResultService<EmployeeServiceDTO>("Nome inválido");
            }

            if (!_validator.ValidateCpf(employeeCreateDto.Cpf.Trim().Replace(".", "").Replace("-", "")))
            {
                return new ResultService<EmployeeServiceDTO>("Cpf inválido");
            }

            if (!_validator.ValidateJobRole(employeeCreateDto.JobRole))
            {
                return new ResultService<EmployeeServiceDTO>("Cargo inválido");
            }

            // Map
            var employeeToCreate = mapCreateDtoToEmployeeModel(employeeCreateDto);
            try
            {
                var result = await _repository.CreateAsync(employeeToCreate);
                var resultDto = MapEmployeeToDto(result);
                return new ResultService<EmployeeServiceDTO>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResultService<EmployeeServiceDTO>("Erro ao criar");
            }
        }

        public async Task<ResultService<EmployeeServiceDTO>> UpdateAsync(EmployeeUpdateDTO employeeUpdateDto)
        {
            if (!await _repository.ExistsById(employeeUpdateDto.Id))
            {
                return new ResultService<EmployeeServiceDTO>("Usuário não localizado");
            }

            var inputEmployee = new EmployeeModel()
            {
                Id = employeeUpdateDto.Id,
                Name = employeeUpdateDto.Name,
                Cpf = employeeUpdateDto.Cpf,
                IsActive = employeeUpdateDto.IsActive,
                JobRole = employeeUpdateDto.JobRole
            };
            try
            {
                var result = await _repository.UpdateAsync(inputEmployee);
                var resultDto = MapEmployeeToDto(result);
                return new ResultService<EmployeeServiceDTO>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResultService<EmployeeServiceDTO>($"Erro ao atualizar: {ex.Message}");
            }
        }

        public async Task<ResultService<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeServiceDTO MapEmployeeToDto(EmployeeModel employeeModel)
        {
            var employeeDto = new EmployeeServiceDTO()
            {
                Name = employeeModel.Name,
                Cpf = employeeModel.Cpf,
                JobRole = employeeModel.JobRole,
                IsActive = employeeModel.IsActive
            };
            return employeeDto;
        }

        public EmployeeModel mapCreateDtoToEmployeeModel(EmployeeCreateDto employeeDto)
        {
            var employeeModel = new EmployeeModel()
            {
                Name = employeeDto.Name,
                Cpf = employeeDto.Cpf.Trim().Replace(".","").Replace("-",""),
                JobRole = employeeDto.JobRole,
                IsActive = true,
                GateLogs = new List<GateLogModel>()
            };
            return employeeModel;
        }
    }
}
