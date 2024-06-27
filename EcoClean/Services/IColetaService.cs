using EcoClean.Models;

namespace EcoClean.Services
{
    public interface IColetaService
    {
        IEnumerable<ColetaModel> ListarColetas();
        ColetaModel ObterColetaPorId(long id);
        void CriarColeta(ColetaModel coleta);
        void AtualizarColeta(ColetaModel coleta);
        void DeletarColeta(long id);
    }
}
