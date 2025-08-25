using Microsoft.EntityFrameworkCore;
using Projeto2DW.Models;

namespace Projeto2DW.Data
{
    public class ApplicationDbContext: DbContext  // Os dois : são a herança no c#
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; } // Criando tabela Usuarios
        public DbSet<Disciplina> Diciplinas { get; set; } // Criando tabela diciplina
        public DbSet<Matricula> Matriculas { get; set; } // Criando tabela matriculas
        public DbSet<Aluno> Alunos { get; set; } // Criando tabela alunos
        public DbSet<Curso> Cursos { get; set; } // Criando tabela cursos
    }
}
