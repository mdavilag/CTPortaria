using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.Exceptions;
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
            if (!_validator.ValidateName(name))
            {
                throw new ValidationException("Nome inválido");
            }

            var visitor = await _repository.GetByNameAsync(name);
            if (visitor == null)
            {
                throw new NotFoundException("Visitante não encontrado");
            }

            return MapVisitorModelToVisitorServiceDto(visitor);
        }

        public async Task<List<VisitorServiceDTO>> GetAllAsync()
        {
            var visitors = await _repository.GetAllAsync();

            return MapVisitorModelToVisitorServiceDto(visitors);
        }

        public async Task<VisitorServiceDTO> GetByIdAsync(int id)
        {
            if (!_validator.ValidateId(id))
            {
                throw new ValidationException("Id inválido");
            }
            var visitor = await _repository.GetByIdAsync(id);
            if (visitor == null)
            {
                throw new NotFoundException("Visitante não encontrado");
            }

            return MapVisitorModelToVisitorServiceDto(visitor);
        }

        public async Task<VisitorServiceDTO> CreateAsync(VisitorCreateDTO visitorToCreate)
        {
            var validateErrors = new List<string>();
            if (!_validator.ValidateCpf(visitorToCreate.Cpf))
            {
                validateErrors.Add("Cpf inválido");
            }

            if (!_validator.ValidateName(visitorToCreate.Name))
            {
                validateErrors.Add("Nome inválido");
            }

            if (!_validator.ValidateName(visitorToCreate.CompanyName))
            {
                validateErrors.Add("Nome da empresa inválido");
            }

            if (validateErrors.Any())
            {
                throw new ValidationException(validateErrors);
            }

            var visitorModel = new VisitorModel()
            {
                Name = visitorToCreate.Name,
                CompanyName = visitorToCreate.CompanyName,
                Cpf = visitorToCreate.Cpf
            };

            var created = await _repository.CreateAsync(visitorModel);
            return MapVisitorModelToVisitorServiceDto(created);
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

        public VisitorServiceDTO MapVisitorModelToVisitorServiceDto(VisitorModel visitorModel)
        {
            var visitorDto = new VisitorServiceDTO()
            {
                Id = visitorModel.Id,
                Name = visitorModel.Name,
                Cpf = visitorModel.Cpf,
                CompanyName = visitorModel.CompanyName
            };

            return visitorDto;
        }

        public List<VisitorServiceDTO> MapVisitorModelToVisitorServiceDto(List<VisitorModel> visitorModels)
        {
            return visitorModels.Select(model => new VisitorServiceDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Cpf = model.Cpf,
                CompanyName = model.CompanyName
            }).ToList();
        }
    }
}
