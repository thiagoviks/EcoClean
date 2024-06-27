using EcoClean.Models;
namespace EcoClean.ViewModel
{
    public class EnderecoViewModel
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<RotaEnderecoModel> RotaEndereco { get; set; }
    }
}
