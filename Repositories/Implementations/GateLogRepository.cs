using CTPortaria.Data;
using CTPortaria.Entities;
using CTPortaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Repositories.Implementations
{
    public class GateLogRepository : IGateLogRepository
    {
        private readonly DataContext _context;

        public GateLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GateLogModel>> GetAllAsync()
        {
            return await _context.GateLogs.ToListAsync();
        }

        public async Task<List<GateLogModel>> GetAllInsideAsync()
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.LeavedAt == null)
                .Include(x=>x.Employee)
                .ToListAsync();
        }

        public async Task<GateLogModel> GetByIdAsync(int id)
        {
            return await _context.GateLogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<GateLogModel>> GetByDayAsync(DateTime date)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x=>x.EnteredAt.Date == date.Date)
                .Include(x=>x.Employee)
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> GetByDateTimeAsync(DateTime initDate, DateTime endDate)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.EnteredAt >= initDate && x.EnteredAt <= endDate)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> GetByEmployeeAsync(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GateLogModel>> GetByVisitorIdentity(string visitorName)
        {
            throw new NotImplementedException();
        }
    }
}
