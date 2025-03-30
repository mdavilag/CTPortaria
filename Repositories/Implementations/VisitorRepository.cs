using CTPortaria.Data;
using CTPortaria.Entities;
using CTPortaria.Exceptions;
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
            await _context.Visitors.AddAsync(visitorToCreate);
            await _context.SaveChangesAsync();
            return visitorToCreate;
        }

        public async Task<VisitorModel> UpdateAsync(VisitorModel visitorToUpdate)
        {
            _context.Visitors.Update(visitorToUpdate);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(visitorToUpdate.Id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var visitorToDelete = await GetByIdAsync(id);
            if (visitorToDelete == null)
            {
                throw new NotFoundException("Visitante não encontrado");
            }

            _context.Visitors.Remove(visitorToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Visitors.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByCpf(string cpf)
        {
            return await _context.Visitors.AnyAsync(x => x.Cpf == cpf);
        }
    }
}
