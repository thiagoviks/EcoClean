using EcoClean.Models;
namespace EcoClean.ViewModel
{
    public class RotaEnderecoViewModel
    {
        public long EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }

        public long RotaId { get; set; }
        public RotaModel Rota { get; set; }
    }
}
