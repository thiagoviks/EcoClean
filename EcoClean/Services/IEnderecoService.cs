using EcoClean.Models;

namespace EcoClean.Services
{
    public interface IEnderecoService
    {
        IEnumerable<EnderecoModel> ListarEnderecos();
        EnderecoModel ObterEnderecoPorId(long id);
        EnderecoModel ObterEnderecoPorCep(string cep);
        void CriarEndereco(EnderecoModel endereco);
        void AtualizarEndereco(EnderecoModel endereco);
        void DeletarEndereco(long id);
    }
}
