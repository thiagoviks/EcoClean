namespace EcoClean.Models
{
    public class NotificacaoModel
    {
        public long Id { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
