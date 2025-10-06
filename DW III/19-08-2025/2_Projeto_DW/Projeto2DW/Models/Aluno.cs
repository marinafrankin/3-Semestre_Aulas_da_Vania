using System.ComponentModel.DataAnnotations;

namespace Projeto2DW.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required, Display(Name = "RA")]
        public int RA { get; set; }
        [Required, Display(Name = "Usuários")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } // Chave estrangueira de Usuario
    }
}
