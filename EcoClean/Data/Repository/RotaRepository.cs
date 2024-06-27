using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class RotaRepository : IRotaRepository
    {
        private readonly DatabaseContext _context;

        public RotaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(RotaModel rota) 
        {
            _context.Rota.Add(rota);
            _context.SaveChanges();
        }

        public void Delete(RotaModel rota)
        {
            _context.Rota.Remove(rota);
            _context.SaveChanges();
        }

        public IEnumerable<RotaModel> GetAll() => _context.Rota.ToList();

        public RotaModel GetById(long Id) => _context.Rota.Find(Id);

        public RotaModel GetByNome(string nome)
        {
            return _context.Rota
               .Where(m => m.Nome == nome)
               .Include(m => m.Id)
               .Include(m => m.Nome)
               .Include(m => m.CreatedAt)
               .Include(m => m.UpdatedAt)
               .FirstOrDefault() as RotaModel;
        }

        public void Update(RotaModel rota)
        {
            _context.Rota.Update(rota);
            _context.SaveChanges();
        }
    }
}
