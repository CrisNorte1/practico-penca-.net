using System.ComponentModel.DataAnnotations;

namespace Penca.Dtos
{
    public class DeporteUpsertDto
    {
        [Required(ErrorMessage = "El nombre del deporte es obligatorio.")]
        public string Name { get; set; } = null!;

        public bool IsTeamSport { get; set; }
    }
}
