using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class MoradorRepository : IMoradorRepository
    {

        private readonly DatabaseContext _context;

        public MoradorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<MoradorModel> GetAll() => _context.Morador.ToList();

        public MoradorModel GetById(long Id) => _context.Morador.Find(Id);

        public MoradorModel FindByEmail(string email)
        {
            return _context.Morador
               .Where(m => m.Email == email)
               .Include(m => m.Id)
               .Include(m => m.Nome)
               .Include(m => m.Email)
               .Include(m => m.EnderecoId)
               .Include(m => m.Endereco)
               .Include(m => m.CreatedAt)
               .Include(m => m.UpdatedAt)
               .FirstOrDefault() as MoradorModel;
        }

        public MoradorModel FindByNome(string nome)
        {
            return _context.Morador
               .Where(m => m.Nome == nome)
               .Include(m => m.Id)
               .Include(m => m.Nome)
               .Include(m => m.Email)
               .Include(m => m.EnderecoId)
               .Include(m => m.Endereco)
               .Include(m => m.CreatedAt)
               .Include(m => m.UpdatedAt)
               .FirstOrDefault() as MoradorModel;
        }
        public void Add(MoradorModel morador)
        {
            _context.Morador.Add(morador);
            _context.SaveChanges();
        }

        public void Update(MoradorModel morador)
        {
            _context.Morador.Update(morador);
            _context.SaveChanges();
        }
        public void Delete(MoradorModel morador)
        {
            _context.Morador.Remove(morador);
            _context.SaveChanges();
        }

    }
}
