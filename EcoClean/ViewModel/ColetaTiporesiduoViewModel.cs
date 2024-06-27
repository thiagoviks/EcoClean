using EcoClean.Models;

namespace EcoClean.ViewModel

{
    public class ColetaTiporesiduoViewModel
    {
        public long ColetaId { get; set; }
        public ColetaModel Coleta { get; set; }

        public long TipoResiduoId { get; set; }
        public TipoResiduoModel TipoResiduo { get; set; }
    }
}
