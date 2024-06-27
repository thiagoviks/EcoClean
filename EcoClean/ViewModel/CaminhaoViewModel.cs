
namespace EcoClean.ViewModel
{
    public class CaminhaoViewModel
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public string CoordenadaX { get; set; }
        public string CoordenadaY { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
