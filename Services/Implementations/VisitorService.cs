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

        public VisitorService(IVisitorRepository repository, IPersonValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<VisitorServiceDTO> GetByNameAsync(string name)
        {
            if (!_validator.ValidateName(name))
            {
                throw new ValidationException("Invalid Name");
            }

            var visitor = await _repository.GetByNameAsync(name);
            if (visitor == null)
            {
                throw new NotFoundException("Visitor not found");
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
                throw new ValidationException("Invalid Id");
            }
            var visitor = await _repository.GetByIdAsync(id);
            if (visitor == null)
            {
                throw new NotFoundException("Visitor not found");
            }

            return MapVisitorModelToVisitorServiceDto(visitor);
        }

        public async Task<VisitorServiceDTO> CreateAsync(VisitorCreateDTO visitorToCreate)
        {
            var validateErrors = new List<string>();
            if (!_validator.ValidateCpf(visitorToCreate.Cpf))
            {
                validateErrors.Add("Invalid CPF");
            }

            if (!_validator.ValidateName(visitorToCreate.Name))
            {
                validateErrors.Add("Invalid Name");
            }

            if (!_validator.ValidateName(visitorToCreate.CompanyName))
            {
                validateErrors.Add("Invalid Company Name");
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

        public async Task<VisitorServiceDTO> UpdateAsync(int id, VisitorCreateDTO visitorToUpdate)
        {
            var validateErrors = new List<string>();
            if (!_validator.ValidateCpf(visitorToUpdate.Cpf))
            {
                validateErrors.Add("Invalid Cpf");
            }

            if (!_validator.ValidateId(id))
            {
                validateErrors.Add("Invalid Id");
            }

            if (!_validator.ValidateName(visitorToUpdate.CompanyName))
            {
                validateErrors.Add("Invalid Company Name");
            }

            if (validateErrors.Any())
            {
                throw new ValidationException(validateErrors);
            }

            var visitor = await _repository.GetByIdAsync(id);
            if (visitor == null)
            {
                throw new NotFoundException("Visitor not found");
            }

            var updatedVisitor = new VisitorModel()
            {
                Id = visitor.Id,
                Name = visitorToUpdate.Name,
                CompanyName = visitorToUpdate.CompanyName,
                Cpf = visitorToUpdate.Cpf
            };
             var update = await _repository.UpdateAsync(updatedVisitor);

             return MapVisitorModelToVisitorServiceDto(update);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (!_validator.ValidateId(id))
            {
                throw new ValidationException("Invalid Id");
            }

            var userToDelete = await _repository.GetByIdAsync(id);

            if (userToDelete == null)
            {
                throw new NotFoundException("Visitor Not Found");
            }

            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<bool> ExistsById(int id)
        {
            if (!_validator.ValidateId(id))
            {
                throw new ValidationException("Invalid id");
            }

            return await _repository.ExistsById(id);
        }

        public async Task<bool> ExistsByCpf(string cpf)
        {
            if (!_validator.ValidateCpf(cpf))
            {
                throw new ValidationException("Invalid CPF");
            }

            return await _repository.ExistsByCpf(cpf);
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
