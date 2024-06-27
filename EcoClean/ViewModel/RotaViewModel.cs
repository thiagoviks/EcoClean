using EcoClean.Models;
namespace EcoClean.ViewModel
{
    public class RotaViewModel
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<RotaEnderecoModel> RotaEndereco { get; set; }
    }
}
