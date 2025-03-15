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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeesResult = await _service.GetAllAsync();
            if (!employeesResult.IsSucess)
            {
                return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(employeesResult.Errors));
            }

            //var employeesViewModelList = employeesResult.Data.Select(x => new EmployeeDetailedViewModel()
            //{
            //    Name = x.Name,
            //    Cpf = x.Cpf,
            //    JobRole = x.JobRole,
            //    IsActive = x.IsActive
            //}).ToList();

            var employeesViewModel = _mapper.Map<List<EmployeeDetailedViewModel>>(employeesResult.Data);

            var resultViewModel = new ResultViewModel<List<EmployeeDetailedViewModel>>(employeesViewModel);
            return Ok(resultViewModel);
        }

        [HttpGet("id/{id:int}")]
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

        #endregion

        #region Posts

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployeeCreateDto employeeCreateDto)
        {
            var created =  await _service.CreateAsync(employeeCreateDto);
            if (!created.IsSucess) return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(created.Errors));
            //var createdViewModel = new EmployeeDetailedViewModel()
            //{
            //    Name = created.Data.Name,
            //    Cpf = created.Data.Cpf,
            //    JobRole = created.Data.JobRole,
            //    IsActive = created.Data.IsActive
            //};

            var createdViewModel = _mapper.Map<EmployeeDetailedViewModel>(created.Data);

            // Alterar a resposta de Ok para Created ou CreatedAtAction
            return StatusCode(201, new ResultViewModel<EmployeeDetailedViewModel>(createdViewModel));
        }

        #endregion

        #region Puts

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] EmployeeUpdateDTO employeeDto)
        {
            var updated = await _service.UpdateAsync(id, employeeDto);
            if (!updated.IsSucess)
            {
                return BadRequest(new ResultViewModel<EmployeeDetailedViewModel>(updated.Errors));
            }

            var updatedViewModel = _mapper.Map<EmployeeDetailedViewModel>(updated.Data);

            return Ok(new ResultViewModel<EmployeeDetailedViewModel>(updatedViewModel));
        }

        #endregion

        #region Deletes

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);
            if (!deleted.Data || !deleted.IsSucess)
            {
                return NotFound(new ResultViewModel<bool>(deleted.Errors));
            }

            return NoContent();
        }

        #endregion
    }
}
