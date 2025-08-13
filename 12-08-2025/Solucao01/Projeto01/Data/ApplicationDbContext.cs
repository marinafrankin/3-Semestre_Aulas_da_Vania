using Microsoft.EntityFrameworkCore;
using Projeto01.Models;

namespace Projeto01.Data
{
    public class ApplicationDbContext: DbContext  // Os dois : são a herança no c#
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
