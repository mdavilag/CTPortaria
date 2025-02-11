using System.Runtime.Intrinsics;
using AutoMapper;
using CTPortaria.DTOs;
using CTPortaria.Services.Implementations;
using CTPortaria.Services.Interfaces;
using CTPortaria.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CTPortaria.Controllers
{
    [ApiController]
    [Route("v1")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // HttpGets

        [HttpGet("employee/name/")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var employee = await _service.GetByNameAsync(name);
            if (!employee.IsSucess)
            {
                return NotFound(new ResultViewModel<EmployeeDetailedViewModel>(employee.Errors));
            }

            //var employeeViewModel = new EmployeeDetailedViewModel()
            //{
            //    Name = employee.Data.Name,
            //    Cpf = employee.Data.Cpf,
            //    JobRole = employee.Data.JobRole,
            //    IsActive = employee.Data.IsActive
            //};
            var employeeViewModel = _mapper.Map<EmployeeDetailedViewModel>(employee.Data);

            return Ok(new ResultViewModel<EmployeeDetailedViewModel>(employeeViewModel));
        }

        [HttpGet("employees/")]
        public async Task<IActionResult> GetAll()
        {
            var employeesResult = await _service.GetAllAsync();
            if (!employeesResult.IsSucess)
            {
                return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(employeesResult.Errors));
            }

            var employeesViewModelList = employeesResult.Data.Select(x => new EmployeeDetailedViewModel()
            {
                Name = x.Name,
                Cpf = x.Cpf,
                JobRole = x.JobRole,
                IsActive = x.IsActive
            }).ToList();

            var resultViewModel = new ResultViewModel<List<EmployeeDetailedViewModel>>(employeesViewModelList);
            return Ok(resultViewModel);
        }

        [HttpGet("employee/id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (!employee.IsSucess)
            {
                return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(employee.Errors));
            }

            //var employeeViewModel = new EmployeeDetailedViewModel()
            //{
            //    Name = employee.Data.Name,
            //    Cpf = employee.Data.Cpf,
            //    JobRole = employee.Data.JobRole,
            //    IsActive = employee.Data.IsActive
            //};

            var employeeViewModel = _mapper.Map<EmployeeDetailedViewModel>(employee.Data);


            return Ok(new ResultViewModel<EmployeeDetailedViewModel>(employeeViewModel));
        }


        // HttpPosts
        [HttpPost("employee/")]
        public async Task<IActionResult> Create([FromBody]EmployeeCreateDto employeeCreateDto)
        {
            var created =  await _service.CreateAsync(employeeCreateDto);
            if (!created.IsSucess) return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(created.Errors));
            var createdViewModel = new EmployeeDetailedViewModel()
            {
                Name = created.Data.Name,
                Cpf = created.Data.Cpf,
                JobRole = created.Data.JobRole,
                IsActive = created.Data.IsActive
            };
            // Alterar a resposta de Ok para Created ou CreatedAtAction
            return Ok(new ResultViewModel<EmployeeDetailedViewModel>(createdViewModel));
        }



    }
}
