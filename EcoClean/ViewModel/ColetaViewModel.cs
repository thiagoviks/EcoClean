using EcoClean.Models;
namespace EcoClean.ViewModel
{
    public class ColetaViewModel
    {
        public long Id { get; set; }
        public long RotaId { get; set; }
        public RotaModel Rota { get; set; }
        public long CaminhaoId { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public long EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }
        public DateTime PrevisaoHorario { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ColetaTipoResiduoModel> ColetaTipoResiduo { get; set; }
    }
}
