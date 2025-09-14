using Microsoft.AspNetCore.Mvc;
using RL201130Desafio2.BL.Interfaces;
using RL201130Desafio2.Entities.DTO;
using System.Net;

namespace RL201130Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _service;

        public InstructorController(IInstructorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InstructorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetInstructoresAsync();
            return (result != null && result.Any()) ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InstructorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _service.GetInstructorByIdAsync(id);
            return (obj != null) ? Ok(obj) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(InstructorDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            int result = await _service.InsertInstructorAsync(model);
            return (result > 0) ? CreatedAtAction("Post", result) : BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InstructorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, InstructorDto model)
        {
            if (model == null || id != model.Codigo)
            {
                return BadRequest();
            }

            var result = await _service.UpdateInstructorAsync(model);
            return (result != null) ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _service.DeleteInstructorAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}