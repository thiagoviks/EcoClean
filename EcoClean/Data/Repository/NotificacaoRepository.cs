using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DatabaseContext _context;

        public NotificacaoRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<NotificacaoModel> GetAll() => _context.Notificacao.ToList();

        public NotificacaoModel GetById(long Id)
        {
            return _context.Notificacao.Find(Id);
        }
        public NotificacaoModel FindByDate(DateTime date)
        {
            return _context.Notificacao
                .Where(n => n.DataEnvio == date)
                .Include(n => n.Id)
                .Include(n => n.DataEnvio)
                .Include(n => n.Destinatario)
                .Include(n => n.Assunto)
                .FirstOrDefault() as NotificacaoModel;
        }

        public NotificacaoModel FindByEmail(string email)
        {
            return _context.Notificacao
                .Where(n => n.Destinatario == email)
                .Include(n => n.Id)
                .Include(n => n.DataEnvio)
                .Include(n => n.Destinatario)
                .Include(n => n.Assunto)
                .FirstOrDefault() as NotificacaoModel;
        }
        public void Add(NotificacaoModel notificacao)
        {
            _context.Notificacao.Add(notificacao);
            _context.SaveChanges();
        }
        public void Update(NotificacaoModel notificacao)
        {
            _context.Notificacao.Update(notificacao);
            _context.SaveChanges();
        }

        public void Delete(NotificacaoModel notificacao)
        {
            _context.Notificacao.Remove(notificacao);
            _context.SaveChanges();
        }

    }
}
