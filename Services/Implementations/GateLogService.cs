using AutoMapper;
using CTPortaria.Data;
using CTPortaria.DTOs;
using CTPortaria.Enums;
using CTPortaria.Exceptions;
using CTPortaria.Repositories.Interfaces;
using CTPortaria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Services.Implementations
{
    public class GateLogService : IGateLogService
    {
        private readonly IGateLogRepository _repository;
        private readonly IMapper _mapper;

        public GateLogService(IGateLogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GateLogServiceDTO>> GetAllAsync()
        {
            try
            {
                var gateLogs = await _repository.GetAllAsync();

                var gateLogDtos = gateLogs
                    .Select(gateLog => new GateLogServiceDTO()
                    {
                        Id = gateLog.Id,
                        Name = gateLog.Employee != null ? gateLog.Employee.Name : gateLog.Visitor.Name,
                        PersonType = gateLog.Employee != null ? EPersonType.Employee : EPersonType.Visitor,
                        Cpf = gateLog.Employee != null ? gateLog.Employee.Cpf : gateLog.Visitor.Cpf,
                        Description = gateLog.Description,
                        EnteredAt = gateLog.EnteredAt,
                        LeavedAt = gateLog.LeavedAt,
                        RegisteredBy = gateLog.RegisteredBy
                    }).ToList();

                return gateLogDtos;

            }
            catch (Exception ex)
            {
                throw new AppException("Erro ao buscar registros: " + ex.Message);
            }
            
        }

        public async Task<List<GateLogServiceDTO>> GetallInsideAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GateLogServiceDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GateLogServiceDTO>> GetByDayAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GateLogServiceDTO>> GetByDateTimeAsync(DateTime initDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GateLogServiceDTO>> GetByEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GateLogServiceDTO>> GetByVisitorCpfAsync(string visitorCpf)
        {
            throw new NotImplementedException();
        }

        public async Task<GateLogServiceDTO> RegisterExitAsync(int gateLogId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
