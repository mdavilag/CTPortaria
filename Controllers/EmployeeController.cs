using System.Runtime.Intrinsics;
using AutoMapper;
using CTPortaria.DTOs;
using CTPortaria.Exceptions;
using CTPortaria.Services.Implementations;
using CTPortaria.Services.Interfaces;
using CTPortaria.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CTPortaria.Controllers
{
    [ApiController]
    [Route("v1/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region Gets

                [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var employee = await _service.GetByNameAsync(name);
            
            var employeeViewModel = _mapper.Map<EmployeeDetailedViewModel>(employee);

            return Ok(employeeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeesResult = await _service.GetAllAsync();

            var employeesViewModel = _mapper.Map<List<EmployeeDetailedViewModel>>(employeesResult);

            return Ok(employeesViewModel);
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            var employeeViewModel = _mapper.Map<EmployeeDetailedViewModel>(employee);

            return Ok(employeeViewModel);
        }

        #endregion

        #region Posts

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployeeCreateDto employeeCreateDto)
        {
            var created =  await _service.CreateAsync(employeeCreateDto);
            
            //var createdViewModel = new EmployeeDetailedViewModel()
            //{
            //    Name = created.Data.Name,
            //    Cpf = created.Data.Cpf,
            //    JobRole = created.Data.JobRole,
            //    IsActive = created.Data.IsActive
            //};

            var createdViewModel = _mapper.Map<EmployeeDetailedViewModel>(created);

            // Alterar a resposta de Ok para Created ou CreatedAtAction
            return StatusCode(201, createdViewModel);
        }

        #endregion

        #region Puts

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] EmployeeUpdateDTO employeeDto)
        {
            var updated = await _service.UpdateAsync(id, employeeDto);
            

            var updatedViewModel = _mapper.Map<EmployeeDetailedViewModel>(updated);

            return Ok(updatedViewModel);
        }

        #endregion

        #region Deletes

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);

            return NoContent();
        }

        #endregion
    }
}
