namespace Projeto2DW.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public int RA { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } // Chave estrangueira de Usuario
    }
}
