using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface INotificacaoRepository
    {
        IEnumerable<NotificacaoModel> GetAll();

        NotificacaoModel GetById(long Id);
        NotificacaoModel FindByDate(DateTime date);
        NotificacaoModel FindByEmail(string email);
        void Add(NotificacaoModel notificacao);
        void Update(NotificacaoModel notificacao);
        void Delete(NotificacaoModel notificacao);
    }
}
