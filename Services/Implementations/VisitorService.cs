﻿using CTPortaria.DTOs;
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
                validateErrors.Add("CPF inválido");
            }

            if (!_validator.ValidateName(visitorToCreate.Name))
            {
                validateErrors.Add("Nome inválido");
            }

            if (!_validator.ValidateName(visitorToCreate.CompanyName))
            {
                validateErrors.Add("Nome de empresa inválida");
            }

            if (await _repository.ExistsByCpf(visitorToCreate.Cpf))
            {
                validateErrors.Add("Cpf já cadastrado");
            }

            if (validateErrors.Any())
            {
                throw new ValidationException(validateErrors);
            }

            var visitorModel = new VisitorModel()
            {
                Name = visitorToCreate.Name,
                CompanyName = visitorToCreate.CompanyName,
                Cpf = visitorToCreate.Cpf,
                GateLogs = new List<GateLogModel>()
            };

            var created = await _repository.CreateAsync(visitorModel);
            return MapVisitorModelToVisitorServiceDto(created);
        }

        public async Task<VisitorServiceDTO> UpdateAsync(int id, VisitorCreateDTO visitorToUpdate)
        {
            var validateErrors = new List<string>();
            if (!_validator.ValidateCpf(visitorToUpdate.Cpf))
            {
                validateErrors.Add("CPF inválido");
            }

            if (!_validator.ValidateId(id))
            {
                validateErrors.Add("Id inválido");
            }

            if (!_validator.ValidateName(visitorToUpdate.CompanyName))
            {
                validateErrors.Add("Nome da empresa inválido");
            }
            
            if (validateErrors.Any())
            {
                throw new ValidationException(validateErrors);
            }
            
            var visitor = await _repository.GetByIdAsync(id);
            if (visitor == null)
            {
                throw new NotFoundException("Visitante não encontrado");
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
                throw new ValidationException("Id inválido");
            }

            var userToDelete = await _repository.GetByIdAsync(id);

            if (userToDelete == null)
            {
                throw new NotFoundException("Visitante não encontrado");
            }

            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<bool> ExistsById(int id)
        {
            if (!_validator.ValidateId(id))
            {
                throw new ValidationException("Id inválido");
            }

            return await _repository.ExistsById(id);
        }

        public async Task<bool> ExistsByCpf(string cpf)
        {
            if (!_validator.ValidateCpf(cpf))
            {
                throw new ValidationException("CPF inválido");
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
