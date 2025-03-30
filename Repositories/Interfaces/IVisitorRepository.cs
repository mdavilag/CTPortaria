using CTPortaria.Entities;

namespace CTPortaria.Repositories.Interfaces
{
    public interface IVisitorRepository
    {
        Task<VisitorModel> GetByNameAsync(string name);
        Task<List<VisitorModel>> GetAllAsync();
        Task<VisitorModel> GetByIdAsync(int id);
        Task<VisitorModel> CreateAsync(VisitorModel visitorToCreate);
        Task<VisitorModel> UpdateAsync(VisitorModel visitorToUpdate);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByCpf(string cpf);
    }
}
