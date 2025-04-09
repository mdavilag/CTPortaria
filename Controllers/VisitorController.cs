using CTPortaria.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VisitorCreateDTO visitorDto)
        {
            var created = await _service.CreateAsync(visitorDto);
            return CreatedAtAction(nameof(GetByIdAsync),new {id = created.Id}, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]int id,[FromBody] VisitorCreateDTO visitorDto)
        {
            var updated = await _service.UpdateAsync(id, visitorDto);
            return Ok(updated);
        }
        
    }
}
