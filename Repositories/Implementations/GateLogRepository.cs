using CTPortaria.Data;
using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Enums;
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
            return await _context.GateLogs
                .Include(x=>x.Employee)
                .Include(x=>x.Visitor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> GetAllInsideAsync()
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.LeavedAt == null)
                .Include(x=>x.Employee)
                .Include(x=>x.Visitor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GateLogModel> GetByIdAsync(int id)
        {
            return await _context.GateLogs
                .Include(x=>x.Employee)
                .Include(x => x.Visitor)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<GateLogModel>> GetByDayAsync(DateTime date)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x=>x.EnteredAt.Date == date.Date)
                .Include(x=>x.Employee)
                .Include(x => x.Visitor)
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> GetByEmployeeAsync(int id)
        {
            return await _context.GateLogs
                .AsNoTracking()
                .Where(x => x.EmployeeId == id)
                .Include(x => x.Employee)
                .Include(x => x.Visitor)
                .ToListAsync();
        }

        public async Task<List<GateLogModel>> SearchQueryAsync(GateLogSearchDTO searchQuery)
        {
            var query = _context.GateLogs
                .Include(x => x.Employee)
                .Include(x => x.Visitor)
                .AsQueryable();

            if (searchQuery.InitDate.HasValue)
            {
                query = query.Where(x => x.EnteredAt >= searchQuery.InitDate.Value);
            }

            if (searchQuery.EndDate.HasValue)
            {
                query = query.Where(x => x.EnteredAt < searchQuery.EndDate.Value.AddDays(1));
            }

            if (!string.IsNullOrWhiteSpace(searchQuery.Cpf))
            {
                query = query.Where(x =>
                    (x.Employee != null && x.Employee.Cpf == searchQuery.Cpf) ||
                    (x.Visitor != null && x.Visitor.Cpf == searchQuery.Cpf));
            }

            if (!string.IsNullOrWhiteSpace(searchQuery.Name))
            {
                query = query.Where(x =>
                    (x.Employee != null && x.Employee.Name.Contains(searchQuery.Name)) ||
                    (x.Visitor != null && x.Visitor.Name.Contains(searchQuery.Name)));
            }

            if (searchQuery.PersonType.HasValue)
            {
                if (searchQuery.PersonType == EPersonType.Employee)
                {
                    query = query.Where(x => x.Employee != null);
                }

                if (searchQuery.PersonType == EPersonType.Visitor)
                {
                    query = query.Where(x => x.Visitor != null);
                }
            }

            return await query.AsNoTracking().ToListAsync();
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
