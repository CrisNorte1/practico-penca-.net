using System.ComponentModel.DataAnnotations;

namespace Penca.Dtos
{
    public class ConfederacionUpsertDto
    {
        [Required(ErrorMessage = "El nombre de la confederación es obligatorio.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "La región de la confederación es obligatoria.")]
        public string Region { get; set; } = null!;

        [Range(1, long.MaxValue, ErrorMessage = "El deporte asociado a la confederación es obligatorio.")]
        public long DeporteId { get; set; }
    }
}
