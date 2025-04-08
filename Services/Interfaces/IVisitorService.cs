using CTPortaria.DTOs;
using CTPortaria.Entities;

namespace CTPortaria.Services.Interfaces
{
    public interface IVisitorService
    {
        Task<VisitorServiceDTO> GetByNameAsync(string name);
        Task<List<VisitorServiceDTO>> GetAllAsync();
        Task<VisitorServiceDTO> GetByIdAsync(int id);
        Task<VisitorServiceDTO> CreateAsync(VisitorCreateDTO visitorToCreate);
        Task<VisitorServiceDTO> UpdateAsync(int id, VisitorCreateDTO visitorToUpdate);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByCpf(string cpf);
    }
}
