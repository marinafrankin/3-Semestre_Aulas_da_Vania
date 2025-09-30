using System.ComponentModel.DataAnnotations;

namespace Projeto2DW.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Preencha o email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        public string? Senha { get; set; }
    }
}
