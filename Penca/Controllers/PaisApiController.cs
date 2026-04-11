using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penca.Dtos;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesApiController : ControllerBase
    {
        private readonly PaisService _paisService;

        public PaisesApiController(PaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public ActionResult<List<PaisDto>> Get()
        {
            var paises = _paisService.GetPaises()
                .Select(MapToDto)
                .ToList();

            return Ok(paises);
        }

        [HttpGet("{id:long}")]
        public ActionResult<PaisDto> GetById(long id)
        {
            var pais = _paisService.GetPaisById(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(MapToDto(pais));
        }

        [HttpPost]
        public ActionResult<PaisDto> Post(PaisUpsertDto paisDto)
        {
            var pais = new Pais
            {
                Codigo = paisDto.Codigo,
                Nombre = paisDto.Nombre,
                FechaFundacion = paisDto.FechaFundacion,
                ConfederacionId = paisDto.ConfederacionId
            };

            _paisService.AddPais(pais);
            var createdPais = _paisService.GetPaisById(pais.Id)!;

            return CreatedAtAction(nameof(GetById), new { id = pais.Id }, MapToDto(createdPais));
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, PaisUpsertDto paisDto)
        {
            var pais = new Pais
            {
                Id = id,
                Codigo = paisDto.Codigo,
                Nombre = paisDto.Nombre,
                FechaFundacion = paisDto.FechaFundacion,
                ConfederacionId = paisDto.ConfederacionId
            };

            if (!_paisService.UpdatePais(pais))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var pais = _paisService.GetPaisById(id);
            if (pais == null)
            {
                return NotFound();
            }

            _paisService.RemovePais(id);
            return NoContent();
        }

        private static PaisDto MapToDto(Pais pais)
        {
            return new PaisDto
            {
                Id = pais.Id,
                Codigo = pais.Codigo,
                Nombre = pais.Nombre,
                FechaFundacion = pais.FechaFundacion,
                ConfederacionId = pais.ConfederacionId,
                ConfederacionNombre = pais.Confederacion.Name
            };
        }
    }
}
