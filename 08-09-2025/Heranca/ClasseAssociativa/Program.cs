Filme filme1 = new Filme("Filme 1", 2025);
Ator ator1 = new Ator("Ator 1");


Ator ator2 = new Ator("Ator 2");

Atuacao atuacao1 = new Atuacao("papel 1", ator1, filme1);
Atuacao atuacao2 = new Atuacao("papel 2", ator2, filme1);

Console.WriteLine($"Filme: {atuacao1.AtuacaoFilme.Titulo} -> {atuacao1.AtuacaoFilme.Ano}");
Console.WriteLine($"Ator: {atuacao1.AtuacaoAtor.Nome}");
Console.WriteLine($"Papel: {atuacao1.Papel}");

Console.ReadKey();

class Filme
{
    public Filme(string titulo, int ano)
    {
        Titulo = titulo;
        Ano = ano;
    }

    public string Titulo { get; set; }
    public int Ano { get; set; }

}

class Ator
{
    public Ator(string nome)
    {
        Nome = nome;
    }

    public string Nome {  get; set; }
}


class Atuacao
{
    public Atuacao(string papel, Ator ator, Filme filme)
    {
        Papel = papel;
        AtuacaoAtor = ator;
        AtuacaoFilme = filme;

    }

    public string Papel { get; set; }
    public Ator AtuacaoAtor { get; set; }
    public Filme AtuacaoFilme { get; set; }
}