using Penca.Models;

namespace Penca.Services
{
    public class ConfederacionService
    {
        private static List<Confederacion> _confederaciones = new List<Confederacion>
        {
            new Confederacion { Id = 1, Name = "CONMEBOL", Region = "Sudamérica" },
            new Confederacion { Id = 2, Name = "UEFA", Region = "Europa" },
            new Confederacion { Id = 3, Name = "CONCACAF", Region = "Norteamérica" }
        };

        public List<Confederacion> GetConfederaciones()
        {
            return _confederaciones;
        }

        public void AddConfederacion(Confederacion conf)
        {
            conf.Id = _confederaciones.Any() ? _confederaciones.Max(c => c.Id) + 1 : 1;
            _confederaciones.Add(conf);
        }

        public void RemoveConfederacion(Confederacion conf)
        {
            _confederaciones.Remove(conf);
        }

        public void UpdateConfederacion(Confederacion conf)
        {
            var existing = _confederaciones.FirstOrDefault(c => c.Id == conf.Id);
            if (existing != null)
            {
                existing.Name = conf.Name;
                existing.Region = conf.Region;
            }
        }
    }
}
