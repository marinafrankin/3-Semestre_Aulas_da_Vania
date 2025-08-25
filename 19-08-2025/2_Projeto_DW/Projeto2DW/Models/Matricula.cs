namespace Projeto2DW.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public DateTime? Data { get; set; } // ou DateOnly

        public Curso? Curso { get; set; } // Relação da classe por objeto de Curso
        public int IdCurso { get; set; } // chave estrangueira de curso

        public Aluno? Aluno { get; set; } // Relação da classe por objeto de Aluno
        public int IdAluno { get; set; } // chave estrangueira de aluno
    }
}
