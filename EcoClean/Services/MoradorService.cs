using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository repository)
        {
            _moradorRepository = repository;
        }

        public void AtualizarMorador(MoradorModel morador) => _moradorRepository.Update(morador);

        public void CriarMorador(MoradorModel morador) => _moradorRepository.Add(morador);

        public void DeletarMorador(long id) 
        {
            var morador = _moradorRepository.GetById(id);
            if (morador != null)
            {
                _moradorRepository.Delete(morador);
            }
        }

        public IEnumerable<MoradorModel> ListarMoradores() => _moradorRepository.GetAll();

        public MoradorModel ObterMoradorPorEmail(string email) => _moradorRepository.FindByEmail(email);

        public MoradorModel ObterMoradorPorId(long id) => _moradorRepository.GetById(id);

        public MoradorModel ObterMoradorPorNome(string nome) => _moradorRepository.FindByNome(nome);
    }
}
