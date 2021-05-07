using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalhador.WebApi.Models;

namespace Trabalhador.WebApi.Data
{
    public class Repository : IRepository
    {
         private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public TrabalhadorClasse GetTrabalhador(string Nome)
        {
            return _context.trabalhador.Where(t => t.Nome == Nome).FirstOrDefault();
        }

        public List<TrabalhadorClasse> GetTrabalhadores()
        {
            return _context.trabalhador.ToList();
        }
    }
}