using CTPortaria.Data;
using CTPortaria.Entities;
using CTPortaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTPortaria.Repositories.Implementations
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly DataContext _context;

        public VisitorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<VisitorModel> GetByNameAsync(string name)
        {
            return await _context.Visitors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<VisitorModel>> GetAllAsync()
        {
            return await _context.Visitors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<VisitorModel> GetByIdAsync(int id)
        {
            return await _context.Visitors
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == id)
        }

        public async Task<VisitorModel> CreateAsync(VisitorModel visitorToCreate)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitorModel> UpdateAsync(VisitorModel visitorToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
