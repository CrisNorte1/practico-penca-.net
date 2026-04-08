using System.ComponentModel.DataAnnotations;

namespace Penca.Models
{
    public class Confederacion
    {
        public long Id { get; set; }
        [Required (ErrorMessage = "El nombre de la confederación es obligatorio.")]
        public string Name { get; set; } = null!;
        [Required (ErrorMessage = "La región de la confederación es obligatoria.")]
        public string Region { get; set; } = null!;
        [Range(1, long.MaxValue, ErrorMessage = "El deporte asociado a la confederación es obligatorio.")]
        public long DeporteId { get; set; }
        // Dejamos solo el ID para crear/editar confederaciones desde el formulario.
        // public Deporte Deporte { get; set; } = null!;
        public List<Pais> Paises { get; set; } = new List<Pais>();

    }
}
