using CTPortaria.Data;
using CTPortaria.Entities;
using CTPortaria.Exceptions;
using CTPortaria.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public async Task<List<GateLogModel>> GetByEmployeeAsync(int id)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.EmployeeId == id)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> GetByVisitorIdentity(string visitorIdentity)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.VisitorIdentity == visitorIdentity)
                .ToListAsync();
        }

        // Create
        public async Task<GateLogModel> CreateAsync(GateLogModel gateLogToCreate)
        {
            await _context.GateLogs.AddAsync(gateLogToCreate);
            await _context.SaveChangesAsync();
            return gateLogToCreate;
        }

        public async Task<GateLogModel> UpdateAsync(GateLogModel gateLogToUpdate)
        {
            _context.GateLogs.Update(gateLogToUpdate);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(gateLogToUpdate.Id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var userToDelete = await GetByIdAsync(id);
            if (userToDelete == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            _context.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
