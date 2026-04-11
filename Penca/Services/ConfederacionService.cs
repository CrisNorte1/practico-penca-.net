using Microsoft.EntityFrameworkCore;
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
            return _context.Confederaciones
                .Include(c => c.Deporte)
                .OrderBy(c => c.Name)
                .ToList();
        }

        public Confederacion? GetConfederacionById(long id)
        {
            return _context.Confederaciones
                .Include(c => c.Deporte)
                .FirstOrDefault(c => c.Id == id);
        }

        public void AddConfederacion(Confederacion conf)
        {
            _context.Confederaciones.Add(conf);
            _context.SaveChanges();
        }

        public void RemoveConfederacion(long id)
        {
            var existing = _context.Confederaciones.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                _context.Confederaciones.Remove(existing);
                _context.SaveChanges();
            }
        }

        public bool UpdateConfederacion(Confederacion conf)
        {
            var existing = _context.Confederaciones
                .FirstOrDefault(c => c.Id == conf.Id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = conf.Name;
            existing.Region = conf.Region;
            existing.DeporteId = conf.DeporteId;
            _context.SaveChanges();
            return true;
        }
    }
}
