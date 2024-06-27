using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoService(ICaminhaoRepository repository)
        {
            _caminhaoRepository = repository;
        }
        public void AtualizarCaminhao(CaminhaoModel coleta) => _caminhaoRepository.Update(coleta);

        public void CriarCaminhao(CaminhaoModel coleta) => _caminhaoRepository.Add(coleta);

        public void DeletarCaminhao(long id) 
        {
            var caminhao = _caminhaoRepository.GetById(id);
            if (caminhao != null)
            {
                _caminhaoRepository.Delete(caminhao);
            }
        }

        public IEnumerable<CaminhaoModel> ListarCaminhoes() => _caminhaoRepository.GetAll();

        public CaminhaoModel ObterCaminhaoPorId(long id) => _caminhaoRepository.GetById(id);
        public CaminhaoModel ObterCaminhaoPorPlaca(string placa) => _caminhaoRepository.GetByPlaca(placa);
    }
}
