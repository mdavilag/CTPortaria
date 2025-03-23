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
    }
}
