using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Repository
{
    public class TipoResiduoRepository : ITipoResiduoRepository
    {
        private readonly DatabaseContext _context;

        public TipoResiduoRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(TipoResiduoModel tipoResiduoModel)
        {
            _context.TipoResiduo.Add(tipoResiduoModel);
            _context.SaveChanges();
        }

        public void Delete(TipoResiduoModel tipoResiduoModel)
        {
            _context.TipoResiduo.Remove(tipoResiduoModel);
            _context.SaveChanges();
        }

        public IEnumerable<TipoResiduoModel> GetAll() => _context.TipoResiduo.ToList();

        public TipoResiduoModel GetById(long Id) => _context.TipoResiduo.Find(Id);

        public TipoResiduoModel GetByNome(string nome)
        {
            return _context.TipoResiduo
               .Where(m => m.Nome == nome)
               .Include(m => m.Id)
               .Include(m => m.Nome)
               .Include(m => m.Descricao)
               .Include(m => m.CreatedAt)
               .Include(m => m.UpdatedAt)
               .FirstOrDefault() as TipoResiduoModel;
        }

        public void Update(TipoResiduoModel tipoResiduoModel)
        {
            _context.TipoResiduo.Update(tipoResiduoModel);
            _context.SaveChanges();
        }
    }
}
