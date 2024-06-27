using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class TipoResiduoService : ITipoResiduoService
    {
        private readonly ITipoResiduoRepository _tipoResiduoRepository;

        public TipoResiduoService(ITipoResiduoRepository repository)
        {
            _tipoResiduoRepository = repository;
        }
        public void AtualizarTipoResiduo(TipoResiduoModel tipoResiduo) => _tipoResiduoRepository.Update(tipoResiduo);
        public void CriarTipoResiduo(TipoResiduoModel tipoResiduo) => _tipoResiduoRepository.Add(tipoResiduo);

        public void DeletarTipoResiduo(long id)
        {
            var tipoResiduo = _tipoResiduoRepository.GetById(id);
            if (tipoResiduo != null)
            {
                _tipoResiduoRepository.Delete(tipoResiduo);
            }
        }

        public IEnumerable<TipoResiduoModel> ListarTipoResiduos() => _tipoResiduoRepository.GetAll();
        public TipoResiduoModel ObterTipoResiduoPorId(long id) => _tipoResiduoRepository.GetById(id);

        public TipoResiduoModel ObterTipoResiduoPorNome(string nome) => _tipoResiduoRepository.GetByNome(nome);
    }
}
