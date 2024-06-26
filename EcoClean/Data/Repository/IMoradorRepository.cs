using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface IMoradorRepository
    {
        IEnumerable<MoradorModel> GetAll();

        MoradorModel GetById(long Id);
        MoradorModel FindByNome(string nome);
        MoradorModel FindByEmail(string email);
        void Add(MoradorModel morador);
        void Update(MoradorModel morador);
        void Delete(MoradorModel morador);
    }
}
