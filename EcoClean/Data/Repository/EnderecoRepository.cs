using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DatabaseContext _context;

        public EnderecoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<EnderecoModel> GetAll() => _context.Endereco.ToList();   
      

        public EnderecoModel GetById(long Id)
        {
            return _context.Endereco.Find(Id);
        }

        public EnderecoModel FindByCep(string Cep)
        {
            return _context.Endereco
                .Where(e => e.Cep == Cep)
                .Include(e => e.Id)
                .Include(e => e.Cep)
                .Include(e => e.Rua)
                .Include(e => e.Bairro)
                .Include(e => e.Numero)
                .Include(e => e.Complemento)
                .Include(e => e.Cidade)
                .Include(e => e.Estado)
                .Include(e => e.CreatedAt)
                .Include(e => e.UpdatedAt)
                .Include(e => e.RotaEndereco)
                .FirstOrDefault() as EnderecoModel;
        }

        public void Add(EnderecoModel endereco)
        {
           _context.Add(endereco);
            _context.SaveChanges();
        }

        public void Update(EnderecoModel endereco)
        {
            _context.Update(endereco);
            _context.SaveChanges();
        }
        public void Delete(EnderecoModel endereco)
        {
            _context.Remove(endereco);
            _context.SaveChanges();
        }
      
    }
}
