using EcoClean.Models;

namespace EcoClean.Services
{
    public interface ICaminhaoService
    {
        IEnumerable<CaminhaoModel> ListarCaminhoes();
        CaminhaoModel ObterCaminhaoPorId(long id);
        CaminhaoModel ObterCaminhaoPorPlaca(string placa);
        void CriarCaminhao(CaminhaoModel coleta);
        void AtualizarCaminhao(CaminhaoModel coleta);
        void DeletarCaminhao(long id);
    }
}
