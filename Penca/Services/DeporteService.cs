using Microsoft.EntityFrameworkCore;
using Penca.Data;
using Penca.Models;

namespace Penca.Services
{
    public class DeporteService
    {
        private readonly AppDbContext _context;

        public DeporteService(AppDbContext context)
        {
            _context = context;
        }

        public List<Deporte> GetDeportes()
        {
            return _context.Deportes
                .Include(d => d.Confederaciones)
                .OrderBy(d => d.Name)
                .ToList();
        }

        public Deporte? GetDeporteById(long id)
        {
            return _context.Deportes
                .Include(d => d.Confederaciones)
                .FirstOrDefault(d => d.Id == id);
        }

        public void AddDeporte(Deporte d)
        {
            _context.Deportes.Add(d);
            _context.SaveChanges();
        }

        public void RemoveDeporte(long id)
        {
            var existing = _context.Deportes.FirstOrDefault(d => d.Id == id);
            if (existing != null)
            {
                _context.Deportes.Remove(existing);
                _context.SaveChanges();
            }
        }

        public bool UpdateDeporte(Deporte d)
        {
            var existing = _context.Deportes
                .FirstOrDefault(x => x.Id == d.Id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = d.Name;
            existing.IsTeamSport = d.IsTeamSport;
            _context.SaveChanges();
            return true;
        }
    }
}
