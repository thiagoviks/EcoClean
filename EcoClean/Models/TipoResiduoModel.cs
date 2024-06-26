namespace EcoClean.Models
{
    public class TipoResiduoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ColetaTipoResiduoModel> ColetaTipoResiduo { get; set; }
    }
}
