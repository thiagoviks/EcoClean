using EcoClean.Models;

namespace EcoClean.ViewModel

{
    public class ColetaTiporesiduoViewModel
    {
        public int ColetaId { get; set; }
        public ColetaModel Coleta { get; set; }

        public int TipoResiduoId { get; set; }
        public TipoResiduoModel TipoResiduo { get; set; }
    }
}
