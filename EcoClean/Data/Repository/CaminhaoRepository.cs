using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly DatabaseContext _context;

        public CaminhaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(CaminhaoModel caminhao)
        {
            _context.Add(caminhao);
            _context.SaveChanges();
        }

        public void Delete(CaminhaoModel caminhao)
        {
            _context.Remove(caminhao);
            _context.SaveChanges();
        }

        public IEnumerable<CaminhaoModel> GetAll() => _context.Caminhao.ToList();

        public CaminhaoModel GetById(long Id) => _context.Caminhao.Find(Id);

        public CaminhaoModel GetByPlaca(string placa)
        {
            return _context.Caminhao
               .Where(c => c.Placa == placa)
               .Include(c => c.Id)
               .Include(c => c.Placa)
               .Include(c => c.CoordenadaX)
               .Include(c => c.CoordenadaY)
               .Include(c => c.CreatedAt)
               .Include(c => c.UpdatedAt)
               .FirstOrDefault() as CaminhaoModel;
        }

        public void Update(CaminhaoModel caminhao)
        {
            _context.Update(caminhao);
            _context.SaveChanges();
        }
    }
}
