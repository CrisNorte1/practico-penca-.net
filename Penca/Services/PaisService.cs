using Microsoft.EntityFrameworkCore;
using Penca.Data;
using Penca.Models;

namespace Penca.Services
{
    public class PaisService
    {
        private readonly AppDbContext _context;

        public PaisService(AppDbContext context)
        {
            _context = context;
        }

        public List<Pais> GetPaises()
        {
            return _context.Paises
                .Include(p => p.Confederacion)
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public Pais? GetPaisById(long id)
        {
            return _context.Paises
                .Include(p => p.Confederacion)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddPais(Pais pais)
        {
            _context.Paises.Add(pais);
            _context.SaveChanges();
        }

        public void RemovePais(long id)
        {
            var existing = _context.Paises.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                _context.Paises.Remove(existing);
                _context.SaveChanges();
            }
        }

        public bool UpdatePais(Pais pais)
        {
            var existingPais = _context.Paises
                .FirstOrDefault(p => p.Id == pais.Id);
            if (existingPais == null)
            {
                return false;
            }

            existingPais.Nombre = pais.Nombre;
            existingPais.Codigo = pais.Codigo;
            existingPais.FechaFundacion = pais.FechaFundacion;
            existingPais.ConfederacionId = pais.ConfederacionId;
            _context.SaveChanges();
            return true;
        }
    }
}
