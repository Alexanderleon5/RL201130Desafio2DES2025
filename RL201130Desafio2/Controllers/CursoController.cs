using Microsoft.AspNetCore.Mvc;
using RL201130Desafio2.BL.Interfaces;
using RL201130Desafio2.Entities.DTO;
using System.Net;

namespace RL201130Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CursoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetCursosAsync();
            return (result != null && result.Any()) ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CursoDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _service.GetCursoByIdAsync(id);
            return (obj != null) ? Ok(obj) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(CursoDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                int result = await _service.InsertCursoAsync(model);
                return (result > 0) ? CreatedAtAction("Post", result) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CursoDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, CursoDto model)
        {
            if (model == null || id != model.Codigo)
            {
                return BadRequest();
            }

            try
            {
                var result = await _service.UpdateCursoAsync(model);
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
            bool result = await _service.DeleteCursoAsync(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}