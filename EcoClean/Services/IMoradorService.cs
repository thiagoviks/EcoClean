using EcoClean.Models;

namespace EcoClean.Services
{
    public interface IMoradorService
    {
        IEnumerable<MoradorModel> ListarMoradores();
        MoradorModel ObterMoradorPorId(long id);
        MoradorModel ObterMoradorPorNome(string nome);
        MoradorModel ObterMoradorPorEmail(string email);
        void CriarMorador(MoradorModel morador);
        void AtualizarMorador(MoradorModel morador);
        void DeletarMorador(long id);
    }
}
