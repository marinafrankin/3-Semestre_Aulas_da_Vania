// Instância dos Filmes
Filme filme1 = new Filme("A lenda do Grow a Garden", 2025);

// Instância dos Atores
Ator ator1 = new Ator("Kaique");
Ator ator2 = new Ator("Jonathan");

// Instância das Atuações
Atuacao atuacao1 = new Atuacao("Jandel", ator1, filme1);

// Exibição de Resultados
Console.WriteLine($"- Filme: {atuacao1.AtuacaoFilme.Titulo} \n- Ator: {atuacao1.AtuacaoAtor.Nome} \n- Papel: {atuacao1.Papel}");

Console.ReadKey();
// Classes
class Filme
{
    public string Titulo { get; set; }
    public int Ano { get; set; }

    public Filme(string titulo, int ano)
    {
        Titulo = titulo;
        Ano = ano;
    }
}

class Ator
{
    public string Nome { get; set; }

    public Ator(string nome)
    {
        Nome = nome;
    }
}

// Relação entre ambos, com atributo PAPEL
class Atuacao
{
    public string Papel { get; set; }
    public Ator AtuacaoAtor { get; set; }
    public Filme AtuacaoFilme { get; set; }

    public Atuacao(string papel, Ator ator, Filme filme)
    {
        Papel = papel;
        AtuacaoAtor = ator;
        AtuacaoFilme = filme;
    }
}