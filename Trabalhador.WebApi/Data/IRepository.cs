using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalhador.WebApi.Models;

namespace Trabalhador.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        List<TrabalhadorClasse> GetTrabalhadores();
        TrabalhadorClasse GetTrabalhador(string nome);
    }
}