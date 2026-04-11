using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penca.Dtos;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeporteApiController : ControllerBase
    {
        private readonly DeporteService _deporteService;

        public DeporteApiController(DeporteService deporteService)
        {
            _deporteService = deporteService;
        }

        [HttpGet]
        public ActionResult<List<DeporteDto>> Get()
        {
            var deportes = _deporteService.GetDeportes()
                .Select(MapToDto)
                .ToList();

            return Ok(deportes);
        }

        [HttpGet("{id:long}")]
        public ActionResult<DeporteDto> GetById(long id)
        {
            var deporte = _deporteService.GetDeporteById(id);
            if (deporte == null)
            {
                return NotFound();
            }

            return Ok(MapToDto(deporte));
        }

        [HttpPost]
        public ActionResult<DeporteDto> Post(DeporteUpsertDto deporteDto)
        {
            var deporte = new Deporte
            {
                Name = deporteDto.Name,
                IsTeamSport = deporteDto.IsTeamSport
            };

            _deporteService.AddDeporte(deporte);
            var createdDeporte = _deporteService.GetDeporteById(deporte.Id)!;

            return CreatedAtAction(nameof(GetById), new { id = deporte.Id }, MapToDto(createdDeporte));
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, DeporteUpsertDto deporteDto)
        {
            var deporte = new Deporte
            {
                Id = id,
                Name = deporteDto.Name,
                IsTeamSport = deporteDto.IsTeamSport
            };

            if (!_deporteService.UpdateDeporte(deporte))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var deporte = _deporteService.GetDeporteById(id);
            if (deporte == null)
            {
                return NotFound();
            }

            _deporteService.RemoveDeporte(id);
            return NoContent();
        }

        private static DeporteDto MapToDto(Deporte deporte)
        {
            return new DeporteDto
            {
                Id = deporte.Id,
                Name = deporte.Name,
                IsTeamSport = deporte.IsTeamSport
            };
        }
    }
}
