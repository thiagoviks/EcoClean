using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;

        public RotaService(IRotaRepository repository)
        {
            _rotaRepository = repository;
        }
        public void AtualizarRota(RotaModel rota) => _rotaRepository.Update(rota);

        public void CriarRota(RotaModel rota) => _rotaRepository.Add(rota);

        public void DeletarRota(long id)
        {
            var rota = _rotaRepository.GetById(id);
            if (rota != null)
            {
                _rotaRepository.Delete(rota);
            }
        }

        public IEnumerable<RotaModel> ListarRotas() => _rotaRepository.GetAll();

        public RotaModel ObterRotaPorId(long id) => _rotaRepository.GetById(id);

        public RotaModel ObterRotaPorNome(string placa) => _rotaRepository.GetByNome(placa);
    }
}