using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penca.Dtos;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfederacionApiController : ControllerBase
    {
        private readonly ConfederacionService _confederacionService;

        public ConfederacionApiController(ConfederacionService confederacionService)
        {
            _confederacionService = confederacionService;
        }

        [HttpGet]
        public ActionResult<List<ConfederacionDto>> Get()
        {
            var confederaciones = _confederacionService.GetConfederaciones()
                .Select(MapToDto)
                .ToList();

            return Ok(confederaciones);
        }

        [HttpGet("{id:long}")]
        public ActionResult<ConfederacionDto> GetById(long id)
        {
            var confederacion = _confederacionService.GetConfederacionById(id);
            if (confederacion == null)
            {
                return NotFound();
            }

            return Ok(MapToDto(confederacion));
        }

        [HttpPost]
        public ActionResult<ConfederacionDto> Post(ConfederacionUpsertDto confederacionDto)
        {
            var confederacion = new Confederacion
            {
                Name = confederacionDto.Name,
                Region = confederacionDto.Region,
                DeporteId = confederacionDto.DeporteId
            };

            _confederacionService.AddConfederacion(confederacion);
            var createdConfederacion = _confederacionService.GetConfederacionById(confederacion.Id)!;

            return CreatedAtAction(nameof(GetById), new { id = confederacion.Id }, MapToDto(createdConfederacion));
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, ConfederacionUpsertDto confederacionDto)
        {
            var confederacion = new Confederacion
            {
                Id = id,
                Name = confederacionDto.Name,
                Region = confederacionDto.Region,
                DeporteId = confederacionDto.DeporteId
            };

            if (!_confederacionService.UpdateConfederacion(confederacion))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var confederacion = _confederacionService.GetConfederacionById(id);
            if (confederacion == null)
            {
                return NotFound();
            }

            _confederacionService.RemoveConfederacion(id);
            return NoContent();
        }

        private static ConfederacionDto MapToDto(Confederacion confederacion)
        {
            return new ConfederacionDto
            {
                Id = confederacion.Id,
                Name = confederacion.Name,
                Region = confederacion.Region,
                DeporteId = confederacion.DeporteId,
                DeporteNombre = confederacion.Deporte.Name
            };
        }
    }
}
