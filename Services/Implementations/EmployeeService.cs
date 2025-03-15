using AutoMapper;
using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Exceptions;
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
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IEmployeeValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<ResultService<EmployeeServiceDTO>> GetByNameAsync(string name)
        {
            if (_validator.ValidateName(name) == false)
            {
                throw new ValidationException(new List<string>() { "Nome não é válido, digite o nome completo" });
                //return new ResultService<EmployeeServiceDTO>("Nome não é válido, digite o nome completo");
            }
            
            var employee = await _repository.GetByNameAsync(name);
            if (employee == null)
            {
                throw new NotFoundException("Usuário não encontrado");
                // return new ResultService<EmployeeServiceDTO>("Erro ao localizar usuário");
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
                    Id = employee.Id,
                    Name = employee.Name,
                    Cpf = employee.Cpf,
                    JobRole = employee.JobRole,
                    IsActive = employee.IsActive
                });

                return new ResultService<List<EmployeeServiceDTO>>(employeeDtos.ToList());
            }
            catch(Exception ex)
            {
                throw new AppException("Erro ao buscar funcionários: " + ex.Message);
                // return new ResultService<List<EmployeeServiceDTO>>(ex.Message);
            }
        }

        public async Task<ResultService<EmployeeServiceDTO>> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new NotFoundException("Usuário não encontrado");
                //return new ResultService<EmployeeServiceDTO>("Usuário não encontrado");
            }

            var employeeDto = MapEmployeeToDto(employee);

            return new ResultService<EmployeeServiceDTO>(employeeDto);
        }

        public async Task<ResultService<EmployeeServiceDTO>> CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            var validationErrors = new List<string>();
            // Validate Properties
            if (!_validator.ValidateName(employeeCreateDto.Name))
            {
                validationErrors.Add("Nome inválido");
                //return new ResultService<EmployeeServiceDTO>("Nome inválido");
            }

            if (!_validator.ValidateCpf(employeeCreateDto.Cpf.Trim().Replace(".", "").Replace("-", "")))
            {
                validationErrors.Add("Cpf inválido");

                // return new ResultService<EmployeeServiceDTO>("Cpf inválido");
            }

            if (!_validator.ValidateJobRole(employeeCreateDto.JobRole))
            {
                validationErrors.Add("Cargo inválido");
                // return new ResultService<EmployeeServiceDTO>("Cargo inválido");
            }

            if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors);
            }

            // Map
            var employeeToCreate = MapCreateDtoToEmployeeModel(employeeCreateDto);
            try
            {
                var result = await _repository.CreateAsync(employeeToCreate);
                var resultDto = MapEmployeeToDto(result);
                return new ResultService<EmployeeServiceDTO>(resultDto);
            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao criar usuário no banco de dados" + ex.Message);
                // return new ResultService<EmployeeServiceDTO>("Erro ao criar");
            }
        }

        public async Task<ResultService<EmployeeServiceDTO>> UpdateAsync(int id, EmployeeUpdateDTO employeeUpdateDto)
        {
            if (!await _repository.ExistsById(id))
            {
                throw new NotFoundException("Usuário não localizado");
                return new ResultService<EmployeeServiceDTO>("Usuário não localizado");
            }

            var inputEmployee = new EmployeeModel()
            {
                Id = id,
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
            try
            {
                if (!await _repository.ExistsById(id))
                {
                    return new ResultService<bool>("Usuário não encontrado");
                }

                await _repository.DeleteByIdAsync(id);
                return new ResultService<bool>(true);
            }
            catch(Exception ex)
            {
                return new ResultService<bool>($"Não foi possivel excluir o usuario: {ex.Message}");
            }
        }

        public EmployeeServiceDTO MapEmployeeToDto(EmployeeModel employeeModel)
        {
            var employeeDto = new EmployeeServiceDTO()
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Cpf = employeeModel.Cpf,
                JobRole = employeeModel.JobRole,
                IsActive = employeeModel.IsActive
            };
            return employeeDto;
        }
        public EmployeeModel MapCreateDtoToEmployeeModel(EmployeeCreateDto employeeDto)
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
