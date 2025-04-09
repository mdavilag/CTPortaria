using AutoMapper;
using CTPortaria.DTOs;
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("day/")]
        public async Task<IActionResult> GetByDay([FromQuery] DateTime date)
        {
            return Ok(await _service.GetByDayAsync(date));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchQueryAsync([FromQuery] GateLogSearchDTO gateLog)
        {
            return Ok(await _service.SearchQueryAsync(gateLog));
        }

        [HttpGet("employeeId/{id:int}")]
        public async Task<IActionResult> GetByEmployeeAsync([FromRoute]int id)
        {
            return Ok(await _service.GetByEmployeeAsync(id));
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
