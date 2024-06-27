using EcoClean.Models;
namespace EcoClean.ViewModel
{
    public class RotaEnderecoViewModel
    {
        public int EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }

        public int RotaId { get; set; }
        public RotaModel Rota { get; set; }
    }
}
