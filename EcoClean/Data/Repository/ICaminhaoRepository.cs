using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface ICaminhaoRepository
    {
        IEnumerable<CaminhaoModel> GetAll();

        CaminhaoModel GetById(long Id);
        CaminhaoModel GetByPlaca(string placa);
        void Add(CaminhaoModel caminhao);
        void Update(CaminhaoModel caminhao);
        void Delete(CaminhaoModel caminhao);
    }
}
