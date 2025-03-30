using CTPortaria.DTOs;
using CTPortaria.Repositories.Interfaces;
using CTPortaria.Services.Interfaces;
using CTPortaria.Utils.Validators;

namespace CTPortaria.Services.Implementations
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _repository;
        private readonly IPersonValidator _validator;
        public async Task<VisitorServiceDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VisitorServiceDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<VisitorServiceDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitorServiceDTO> CreateAsync(VisitorCreateDTO visitorToCreate)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitorServiceDTO> UpdateAsync(VisitorCreateDTO visitorToUpdate)
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
