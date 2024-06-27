namespace EcoClean.Models
{
    public class ColetaTipoResiduoModel
    {
        public long ColetaId { get; set; }
        public ColetaModel Coleta { get; set; }

        public long TipoResiduoId { get; set; }
        public TipoResiduoModel TipoResiduo { get; set; }
    }
}
