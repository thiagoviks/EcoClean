using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface IRotaRepository
    {
        IEnumerable<RotaModel> GetAll();

        RotaModel GetById(long Id);
        RotaModel GetByNome(string nome);
        void Add(RotaModel rota);
        void Update(RotaModel rota);
        void Delete(RotaModel rota);
    }
}
