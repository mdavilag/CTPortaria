using AutoMapper;
using CTPortaria.Data;
using CTPortaria.DTOs;
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
            throw new NotImplementedException();
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
