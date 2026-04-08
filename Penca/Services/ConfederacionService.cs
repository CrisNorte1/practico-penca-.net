using Penca.Data;
using Penca.Models;

namespace Penca.Services
{
    public class ConfederacionService
    {
        private readonly AppDbContext _context;

        public ConfederacionService(AppDbContext context)
        {
            _context = context;
        }

        public List<Confederacion> GetConfederaciones()
        {
            return _context.Confederaciones.ToList();
        }

        public void AddConfederacion(Confederacion conf)
        {
            _context.Confederaciones.Add(conf);
            _context.SaveChanges();
        }

        public void RemoveConfederacion(Confederacion conf)
        {
            var existing = _context.Confederaciones.Find(conf.Id);
            if (existing != null)
            {
                _context.Confederaciones.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void UpdateConfederacion(Confederacion conf)
        {
            var existing = _context.Confederaciones.Find(conf.Id);
            if (existing != null)
            {
                existing.Name = conf.Name;
                existing.Region = conf.Region;
                existing.DeporteId = conf.DeporteId;
                _context.SaveChanges();
            }
        }
    }
}
