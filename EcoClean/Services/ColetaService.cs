using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class ColetaService : IColetaService
    {
        private readonly IColetaRepository _coletaRepository;
        
        public ColetaService(IColetaRepository repository)
        {
            _coletaRepository = repository;
        }
        public void AtualizarColeta(ColetaModel coleta) => _coletaRepository.Update(coleta);

        public void CriarColeta(ColetaModel coleta) => _coletaRepository.Add(coleta);

        public void DeletarColeta(long id)
        {
            var coleta = _coletaRepository.GetById(id);
            if (coleta != null) { 
                _coletaRepository.Delete(coleta);
            }
        }

        public IEnumerable<ColetaModel> ListarColetas() => _coletaRepository.GetAll();
       
        public ColetaModel ObterColetaPorId(long id) => _coletaRepository.GetById(id);

    }
}
