namespace Projeto2DW.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public List<Disciplina> Diciplinas { get; set; }  // Lista de Disciplinas
    }
}
