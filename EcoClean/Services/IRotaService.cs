using EcoClean.Models;

namespace EcoClean.Services
{
    public interface IRotaService
    {
        IEnumerable<RotaModel> ListarRotas();
        RotaModel ObterRotaPorId(long id);
        RotaModel ObterRotaPorNome(string placa);
        void CriarRota(RotaModel rota);
        void AtualizarRota(RotaModel rota);
        void DeletarRota(long id);
    }
}
