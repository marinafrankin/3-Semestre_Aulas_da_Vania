

/*
     1.	Um sistema que calcula a média de um aluno com 
base em duas notas. Se a quantidade de provas for 0,
trata a exceção.

*/

var aluno = new Aluno("Amanda");

aluno.AdicionarAvaliacao(new Avaliacao(aluno, 9));
aluno.AdicionarAvaliacao(new Avaliacao(aluno, 6));

float MediaFinal(ICollection<Avaliacao> avaliacaos)
{
    if (avaliacaos.Count == 0)
    {
        throw new Exception("Não há avalições !");
    }

    float total = 0;
    foreach (var prova in avaliacaos)
    {
        total += prova.NotaFinal;
    }
    return total / avaliacaos.Count;
}

try
{
    Console.WriteLine(MediaFinal(aluno.Avaliacoes));
}
catch (Exception e)
{ 
    Console.WriteLine($"{e.Message}");
}

class Aluno
{
    public string Nome {  get; set; }
    public List<Avaliacao> Avaliacoes 
    { get; set; } = new List<Avaliacao>();
    public Aluno(string nome)
    { 
        Nome = nome;
    }
    public void AdicionarAvaliacao(Avaliacao avaliacao)
    {
        Avaliacoes.Add(avaliacao);
    }
}


class Avaliacao
{
    public Aluno Aluno { get; set; }
    public float NotaFinal { get; set; }
    public Avaliacao(Aluno aluno, float notaFinal)
    {
        Aluno = aluno;
        NotaFinal = notaFinal;
    }
}