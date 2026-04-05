using Penca.Models;

namespace Penca.Services
{
    public class DeporteService
    {
        private static List<Deporte> _deportes = new List<Deporte>
        {
            new Deporte { Id = 1, Name = "Fútbol", IsTeamSport = true },
            new Deporte { Id = 2, Name = "Tenis", IsTeamSport = false },
            new Deporte { Id = 3, Name = "Básquet", IsTeamSport = true }
        };

        public List<Deporte> GetDeportes() => _deportes;

        public void AddDeporte(Deporte d)
        {
            d.Id = _deportes.Any() ? _deportes.Max(x => x.Id) + 1 : 1;
            _deportes.Add(d);
        }

        public void RemoveDeporte(Deporte d) => _deportes.Remove(d);

        public void UpdateDeporte(Deporte d)
        {
            var existing = _deportes.FirstOrDefault(x => x.Id == d.Id);
            if (existing != null)
            {
                existing.Name = d.Name;
                existing.IsTeamSport = d.IsTeamSport;
            }
        }
    }
}
