using EcoClean.Models;

namespace EcoClean.Services
{
    public interface INotificacaoService
    {
        IEnumerable<NotificacaoModel> ListarNotificacoes();
        NotificacaoModel ObterNotificacaoPorId(long id);
        NotificacaoModel ObterNotificacaoPorData(DateTime data);
        NotificacaoModel ObterNotificacaoPorEmail(string email);
        void CriarNotificacao(NotificacaoModel notificacao);
        void AtualizarNotificacao(NotificacaoModel notificacao);
        void DeletarNotificacao(long id);
    }
}
