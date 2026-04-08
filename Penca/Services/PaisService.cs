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
            return _context.Paises.ToList();
        }

        public void AddPais(Pais pais)
        {
            _context.Paises.Add(pais);
            _context.SaveChanges();
        }

        public void RemovePais(Pais pais)
        {
            var existing = _context.Paises.Find(pais.Id);
            if (existing != null)
            {
                _context.Paises.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void UpdatePais(Pais pais)
        {
            var existingPais = _context.Paises.Find(pais.Id);
            if (existingPais != null)
            {
                existingPais.Nombre = pais.Nombre;
                existingPais.Codigo = pais.Codigo;
                existingPais.FechaFundacion = pais.FechaFundacion;
                existingPais.ConfederacionId = pais.ConfederacionId;
                _context.SaveChanges();
            }
        }
    }
}
