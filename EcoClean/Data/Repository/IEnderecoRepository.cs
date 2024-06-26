using EcoClean.Models;

namespace EcoClean.Data.Repository
{
    public interface IEnderecoRepository
    {
        IEnumerable<EnderecoModel> GetAll();

        EnderecoModel GetById(long id);
        EnderecoModel FindByNome(string nome);
        EnderecoModel FindByEmail(string email);
        void Add(EnderecoModel endereco);
        void Update(EnderecoModel endereco);
        void Delete(EnderecoModel endereco);
    }
}
