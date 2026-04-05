using Penca.Models;

namespace Penca.Services
{
    public class PaisService
    {

        private static List<Pais> _paises = new List<Pais>
        {
            new Pais { Id = 1, Nombre = "Argentina" },
            new Pais { Id = 2, Nombre = "Brasil" },
            new Pais { Id = 3, Nombre = "Chile" },
            new Pais { Id = 4, Nombre = "Uruguay" },
            new Pais { Id = 5, Nombre = "Paraguay" }
        };

        public List<Pais> GetPaises()
        {
            return _paises;
        }

        public void AddPais(Pais pais)
        {
            pais.Id = _paises.Max(p => p.Id) + 1;
            _paises.Add(pais);
        }

        public void RemovePais(Pais pais) {
            _paises.Remove(pais);
        }

        public void UpdatePais(Pais pais)
        {
            var existingPais = _paises.FirstOrDefault(p => p.Id == pais.Id);
            if (existingPais != null)
            {
                existingPais.Nombre = pais.Nombre;
                existingPais.Codigo = pais.Codigo;
                existingPais.FechaFundacion = pais.FechaFundacion;
            }
        }
    }
}
