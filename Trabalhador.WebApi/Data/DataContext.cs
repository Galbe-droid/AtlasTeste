using Microsoft.EntityFrameworkCore;
using Trabalhador.WebApi.Models;

namespace Trabalhador.WebApi.Data
{
    public class DataContext: DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<TrabalhadorClasse> trabalhador { get; set; }
    }
}