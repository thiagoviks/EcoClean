namespace EcoClean.Models
{
    public class RotaEnderecoModel
    {
        public long EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }

        public long RotaId { get; set; }
        public RotaModel Rota { get; set; }
    }
}
