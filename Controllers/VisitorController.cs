using CTPortaria.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CTPortaria.Controllers
{
    [ApiController]
    [Route("v1/Visitors")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _service;

        public VisitorController(IVisitorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByNameAsync([FromQuery]string name)
        {
            var visitor = await _service.GetByNameAsync(name);
            return Ok(visitor);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
