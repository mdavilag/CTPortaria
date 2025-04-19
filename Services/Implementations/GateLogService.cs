using AutoMapper;
using CTPortaria.Data;
using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Enums;
using CTPortaria.Exceptions;
using CTPortaria.Repositories.Interfaces;
using CTPortaria.Services.Interfaces;
using CTPortaria.Utils.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Services.Implementations
{
    public class GateLogService : IGateLogService
    {
        private readonly IGateLogRepository _repository;
        private readonly IPersonValidator _validator;
        private readonly IMapper _mapper;

        public GateLogService(IGateLogRepository repository, IMapper mapper, IPersonValidator validator)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<List<GateLogServiceDTO>> GetAllAsync()
        {
            try
            {
                var gateLogs = await _repository.GetAllAsync();

                return MapGateLogToGateLogServiceDto(gateLogs);

            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao buscar registros no Banco de dados: " + ex.Message);
            }
            
        }

        public async Task<List<GateLogServiceDTO>> GetAllInsideAsync()
        {
            try
            {
                var gateLogs = await _repository.GetAllInsideAsync();

                return MapGateLogToGateLogServiceDto(gateLogs);
            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao buscar registros no Banco de dados " + ex.Message);
            }
        }

        public async Task<GateLogServiceDTO> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ValidationException(new List<string>() { "Id inválido" });
            }

            try
            {
                var gateLog = await _repository.GetByIdAsync(id);
                if (gateLog == null)
                {
                    throw new NotFoundException("Registro não localizado");
                }

                return MapGateLogToGateLogServiceDto(gateLog);

            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao localizar usuário: " + ex.Message);
            }
        }

        public async Task<List<GateLogServiceDTO>> GetByDayAsync(DateTime date)
        {
            if (date == null)
            {
                throw new ValidationException(new List<string>() { "Data de pesquisa inválida" });
            }

            try
            {
                var gateLogs = await _repository.GetByDayAsync(date);
                return MapGateLogToGateLogServiceDto(gateLogs);
            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao localizar registros: " + ex.Message);
            }
        }


        public async Task<List<GateLogServiceDTO>> GetByEmployeeAsync(int id)
        {
            if (id < 0) throw new ValidationException("Id inválido");

            try
            {
                var gateLogs = await _repository.GetByEmployeeAsync(id);
                return MapGateLogToGateLogServiceDto(gateLogs);
            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao localizar registros " + ex.Message);
            }
        }


        public async Task<List<GateLogServiceDTO>> SearchQueryAsync(GateLogSearchDTO searchQuery)
        {
            if (searchQuery.InitDate != null)
            {
                searchQuery.InitDate = searchQuery.InitDate.Value.Date;
            }
            if (searchQuery.EndDate != null)
            {
                searchQuery.EndDate = searchQuery.EndDate.Value.Date;
            }

            if (!string.IsNullOrWhiteSpace(searchQuery.Cpf))
            {
                if (!_validator.ValidateCpf(searchQuery.Cpf))
                {
                    throw new ValidationException("Cpf inválido");
                }

                searchQuery.Cpf = _validator.CleanCpf(searchQuery.Cpf);
            }
            
            var gateLogs = await _repository.SearchQueryAsync(searchQuery);

            return MapGateLogToGateLogServiceDto(gateLogs);
        }

        public async Task<GateLogServiceDTO> CreateAsync(GateLogCreateDTO gateLogToCreate)
        {
            var validationErrors = new List<string>();
            if (gateLogToCreate.EmployeeId == null && gateLogToCreate.VisitorId == null)
            {
                validationErrors.Add("Nenhuma informação de pessoa recebida");
            }

            if (gateLogToCreate.EnteredAt == default)
            {
                validationErrors.Add("Horário de entrada inválido");
            }

            if (!_validator.ValidateName(gateLogToCreate.RegisteredBy))
            {
                validationErrors.Add("Nome do porteiro inválido");
            }

            var personType = gateLogToCreate.EmployeeId != null ? EPersonType.Employee : EPersonType.Visitor;
            var personId = gateLogToCreate.EmployeeId != null ? gateLogToCreate.EmployeeId : gateLogToCreate.VisitorId;
            if (await _repository.IsPersonInside(personType, personId))
            {
                validationErrors.Add("Pessoa já está dentro do local");
            }
            
        if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors);
            }

            var createModel = new GateLogModel()
            {
                EmployeeId = gateLogToCreate.EmployeeId,
                VisitorId = gateLogToCreate.EmployeeId == null ? gateLogToCreate.VisitorId : null,
                EnteredAt = gateLogToCreate.EnteredAt,
                CreatedAt = DateTime.Now,
                RegisteredBy = gateLogToCreate.RegisteredBy,
                Description = string.IsNullOrEmpty(gateLogToCreate.Description) ? "" : gateLogToCreate.Description
            };

            var createResult = await _repository.CreateAsync(createModel);

            return MapGateLogToGateLogServiceDto(createResult);

        }

        public async Task<GateLogServiceDTO> RegisterExitAsync(int gateLogId)
        {
            var gateLog = await _repository.GetByIdAsync(gateLogId);
            if (gateLog == null)
            {
                throw new NotFoundException("Registro não encontrado");
            }

            if (gateLog.LeavedAt != null)
            {
                throw new ValidationException("Registro já contém uma data de saída");
            }

            gateLog.LeavedAt = DateTime.Now;
            var updatedGateLog = await _repository.UpdateAsync(gateLog);

            return MapGateLogToGateLogServiceDto(updatedGateLog);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var gateLogToDelete = await _repository.GetByIdAsync(id);
            if (gateLogToDelete == null)
            {
                throw new NotFoundException("Registro não encontrado");
            }

            return await _repository.DeleteByIdAsync(id);
        }

        public List<GateLogServiceDTO> MapGateLogToGateLogServiceDto(List<GateLogModel> gateLogs)
        {
            var gateLogDtos = gateLogs
                .Select(gateLog => new GateLogServiceDTO()
                {
                    Id = gateLog.Id,
                    Name = gateLog.Employee != null ? gateLog.Employee.Name : gateLog.Visitor.Name,
                    PersonType = gateLog.Employee != null ? EPersonType.Employee.ToString() : EPersonType.Visitor.ToString(),
                    Cpf = gateLog.Employee != null ? gateLog.Employee.Cpf : gateLog.Visitor.Cpf,
                    Description = gateLog.Description,
                    EnteredAt = gateLog.EnteredAt,
                    LeavedAt = gateLog.LeavedAt,
                    RegisteredBy = gateLog.RegisteredBy
                }).ToList();

            return gateLogDtos;
        }

        public GateLogServiceDTO MapGateLogToGateLogServiceDto(GateLogModel gateLog)
        {
            var gateLogDto = new GateLogServiceDTO()
            {
                Id = gateLog.Id,
                Name = gateLog.Employee != null ? gateLog.Employee.Name : gateLog.Visitor.Name,
                PersonType = gateLog.EmployeeId != null ? EPersonType.Employee.ToString() : EPersonType.Visitor.ToString(),
                Cpf = gateLog.EmployeeId != null ? gateLog.Employee.Cpf : gateLog.Visitor.Cpf,
                Description = gateLog.Description,
                EnteredAt = gateLog.EnteredAt,
                LeavedAt = gateLog.LeavedAt,
                RegisteredBy = gateLog.RegisteredBy
            };
            return gateLogDto;
        }
    }
}
