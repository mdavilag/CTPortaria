using AutoMapper;
using CTPortaria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CTPortaria.Controllers
{
    [ApiController] 
    [Route("v1/GateLogs")]
    public class GateLogController : ControllerBase
    {
        private readonly IGateLogService _service;
        private readonly IMapper _mapper;

        public GateLogController(IGateLogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("inside")]
        public async Task<IActionResult> GetAllInsideAsync()
        {
            return Ok(await _service.GetAllInsideAsync());
        }
        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("day/")]
        public async Task<IActionResult> GetByDay([FromQuery] DateTime date)
        {
            return Ok(await _service.GetByDayAsync(date));
        }

        [HttpGet("datetime/")]
        public async Task<IActionResult> GetByDateTime([FromQuery] DateTime initDate, DateTime endDate)
        {
            return Ok(await _service.GetByDateTimeAsync(initDate, endDate));
        }

        [HttpGet("employeeId/{id:int}")]
        public async Task<IActionResult> GetByEmployeeAsync([FromRoute]int id)
        {
            return Ok(await _service.GetByEmployeeAsync(id));
        }
        [HttpGet("visitorCpf/{cpf}")]
        public async Task<IActionResult> GetByVisitorAsync([FromRoute] string cpf)
        {
            return Ok(await _service.GetByVisitorCpfAsync(cpf));
        }

        [HttpPut("exit/{id:int}")]
        public async Task<IActionResult> RegisterExitAsync([FromRoute] int id)
        {
            return Ok(await _service.RegisterExitAsync(id));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.DeleteByIdAsync(id));
        }

    }
}
