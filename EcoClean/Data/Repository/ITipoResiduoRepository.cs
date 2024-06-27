using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface ITipoResiduoRepository
    {
        IEnumerable<TipoResiduoModel> GetAll();

        TipoResiduoModel GetById(long Id);
        TipoResiduoModel GetByNome(string nome);
        void Add(TipoResiduoModel tipoResiduoModel);
        void Update(TipoResiduoModel tipoResiduoModel);
        void Delete(TipoResiduoModel tipoResiduoModel);
    }
}
