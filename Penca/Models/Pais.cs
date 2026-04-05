using System.ComponentModel.DataAnnotations;

namespace Penca.Models
{
    public class Pais
    {
        public long Id { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código del país debe tener exactamente 3 caracteres.")]
        [Required (ErrorMessage = "El código del país es obligatorio.")]
        public string Codigo { get; set; }
        [Required (ErrorMessage = "El nombre del país es obligatorio.")]
        public string Nombre { get; set; }
        [Required (ErrorMessage = "La fecha de fundación del país es obligatoria.")]
        public DateTime FechaFundacion { get; set; }

    }
}
