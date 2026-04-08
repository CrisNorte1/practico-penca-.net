using System.ComponentModel.DataAnnotations;

namespace Penca.Models
{
    public class Deporte
    {
        public long Id { get; set; }
        [Required (ErrorMessage = "El nombre del deporte es obligatorio.")]
        public string Name { get; set; } = null!;
        public bool IsTeamSport { get; set; }
        public List<Confederacion> Confederaciones { get; set; } = new List<Confederacion>();

    }
}
