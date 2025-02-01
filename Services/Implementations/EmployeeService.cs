﻿using CTPortaria.DTOs;
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

        public EmployeeService(IEmployeeRepository repository, EmployeeValidator validator)
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
            throw new NotImplementedException();
            // validar propriedades
        }

        public async Task<ResultService<EmployeeServiceDTO>> UpdateAsync(EmployeeServiceDTO employeeServiceDTO)
        {
            throw new NotImplementedException();
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

        public EmployeeModel mapDtoToEmployeeModel(EmployeeServiceDTO employeeDto)
        {
            var employeeModel = new EmployeeModel()
            {
                Name = employeeDto.Name,
                Cpf = employeeDto.Cpf,
                JobRole = employeeDto.JobRole,
                IsActive = employeeDto.IsActive,
                GateLogs = new List<GateLogModel>()
            };
            return employeeModel;
        }
    }
}
