namespace Penca.Dtos
{
    public class PaisDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime FechaFundacion { get; set; }
        public long ConfederacionId { get; set; }
        public string ConfederacionNombre { get; set; } = null!;
    }
}
