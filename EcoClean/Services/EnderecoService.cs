using EcoClean.Data.Repository;
using EcoClean.Models;

namespace EcoClean.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _enderecoRepository = repository;
        }
        public void AtualizarEndereco(EnderecoModel endereco) => _enderecoRepository.Update(endereco);

        public void CriarEndereco(EnderecoModel endereco) =>_enderecoRepository.Add(endereco);

        public void DeletarEndereco(long id) {
            var endereco = _enderecoRepository.GetById(id);
            if (endereco != null)
            {
                _enderecoRepository.Delete(endereco);
            }
        }
 

        public IEnumerable<EnderecoModel> ListarEnderecos() => _enderecoRepository.GetAll();

        public EnderecoModel ObterEnderecoPorCep(string cep) => _enderecoRepository.FindByCep(cep);

        public EnderecoModel ObterEnderecoPorId(long id) => _enderecoRepository.GetById(id);

    }
}
