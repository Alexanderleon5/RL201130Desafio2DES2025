using Microsoft.AspNetCore.Mvc;
using RL201130Desafio2.BL.Interfaces;
using RL201130Desafio2.Entities.DTO;
using System.Net;

namespace RL201130Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _service;

        public InscripcionController(IInscripcionService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InscripcionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetInscripcionesAsync();
            return (result != null && result.Any()) ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InscripcionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _service.GetInscripcionByIdAsync(id);
            return (obj != null) ? Ok(obj) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(InscripcionDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                int result = await _service.InsertInscripcionAsync(model);
                return (result > 0) ? CreatedAtAction("Post", result) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InscripcionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, InscripcionDto model)
        {
            if (model == null || id != model.Codigo)
            {
                return BadRequest();
            }

            try
            {
                var result = await _service.UpdateInscripcionAsync(model);
                return (result != null) ? Ok(result) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _service.DeleteInscripcionAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}