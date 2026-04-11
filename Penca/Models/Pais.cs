using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Penca.Models
{
    public class Pais
    {
        public long Id { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código del país debe tener exactamente 3 caracteres.")]
        [Required (ErrorMessage = "El código del país es obligatorio.")]
        public string Codigo { get; set; } = null!;
        [Required (ErrorMessage = "El nombre del país es obligatorio.")]
        public string Nombre { get; set; } = null!;
        [Required (ErrorMessage = "La fecha de fundación del país es obligatoria.")]
        public DateTime FechaFundacion { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "La confederación es obligatoria.")]
        public long ConfederacionId { get; set; }
        [ValidateNever]
        public Confederacion Confederacion { get; set; } = null!;

    }
}
