using EcoClean.Models;

namespace EcoClean.Services
{
    public interface ITipoResiduoService
    {
        IEnumerable<TipoResiduoModel> ListarTipoResiduos();
        TipoResiduoModel ObterTipoResiduoPorId(long id);
        TipoResiduoModel ObterTipoResiduoPorNome(string nome);
        void CriarTipoResiduo(TipoResiduoModel tipoResiduo);
        void AtualizarTipoResiduo(TipoResiduoModel tipoResiduo);
        void DeletarTipoResiduo(long id);
    }
}
