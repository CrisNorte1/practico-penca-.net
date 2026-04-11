namespace Penca.Dtos
{
    public class ConfederacionDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public long DeporteId { get; set; }
        public string DeporteNombre { get; set; } = null!;
    }
}
