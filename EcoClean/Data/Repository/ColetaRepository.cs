using EcoClean.Data.Contexts;
using EcoClean.Models;
using Microsoft.EntityFrameworkCore;


namespace EcoClean.Data.Repository
{
    public class ColetaRepository : IColetaRepository
    {
        private readonly DatabaseContext _context;

        public ColetaRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public IEnumerable<ColetaModel> GetAll() => _context.Coleta.ToList();

        public ColetaModel GetById(long Id)
        {
          return _context.Coleta.Find(Id);
        }


        public void Add(ColetaModel coleta)
        {
            _context.Coleta.Add(coleta);
            _context.SaveChanges();
        }
        public void Update(ColetaModel coleta)
        {
            _context.Update(coleta);
            _context.SaveChanges();

        }
        public void Delete(ColetaModel coleta)
        {
            _context.Coleta.Remove(coleta);
            _context.SaveChanges();
        }

       
    }
}
