﻿using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoService(INotificacaoRepository repository)
        {
            _notificacaoRepository = repository;
        }
        public void CriarNotificacao(NotificacaoModel notificacao) => _notificacaoRepository.Add(notificacao);

        public IEnumerable<NotificacaoModel> ListarNotificacoes() => _notificacaoRepository.GetAll();

        public void AtualizarNotificacao(NotificacaoModel notificacao) => _notificacaoRepository.Update(notificacao); 

        public void DeletarNotificacao(NotificacaoModel notificacao) => _notificacaoRepository.Delete(notificacao);

        public NotificacaoModel ObterMoradorPorId(long id) => _notificacaoRepository.GetById(id);

        public NotificacaoModel ObterNotificacaoPorData(DateTime data) => _notificacaoRepository.FindByDate(data);

        public NotificacaoModel ObterNotificacaoPorEmail(string email) => _notificacaoRepository.FindByEmail(email);
    }
}
