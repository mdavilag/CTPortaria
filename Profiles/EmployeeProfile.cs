using AutoMapper;
using CTPortaria.DTOs;
using CTPortaria.Entities;
using CTPortaria.ViewModels;

namespace CTPortaria.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, EmployeeServiceDTO>();
            CreateMap<EmployeeServiceDTO, EmployeeDetailedViewModel>();
            CreateMap<EmployeeUpdateDTO, EmployeeDetailedViewModel>();
        }
    }
}
