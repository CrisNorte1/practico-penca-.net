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
            return _context.Deportes.ToList();
        }

        public void AddDeporte(Deporte d)
        {
            _context.Deportes.Add(d);
            _context.SaveChanges();
        }

        public void RemoveDeporte(Deporte d)
        {
            var existing = _context.Deportes.Find(d.Id);
            if (existing != null)
            {
                _context.Deportes.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void UpdateDeporte(Deporte d)
        {
            var existing = _context.Deportes.Find(d.Id);
            if (existing != null)
            {
                existing.Name = d.Name;
                existing.IsTeamSport = d.IsTeamSport;
                _context.SaveChanges();
            }
        }
    }
}
