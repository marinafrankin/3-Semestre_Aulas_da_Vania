namespace Projeto2DW.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string? Nome { get; set; }
        public int CursoId { get; set; } // chave estrangueira de Curso
        public Curso? Curso { get; set; } // Relação da classe por objeto do Curso
    }
}
