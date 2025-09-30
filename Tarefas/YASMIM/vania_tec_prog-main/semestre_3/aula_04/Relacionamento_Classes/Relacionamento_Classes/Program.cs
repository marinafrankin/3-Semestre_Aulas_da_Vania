// Não é necessario instanciar Pessoa antes pois professor já herda todos os atributos, possibilitando a criação direta
Professor professor = new Professor("Vera", "Prof.", "14 991259992");

Console.WriteLine($"Celular da {professor.Titulacao} {professor.Nome}: {professor.Celular}");
Console.ReadKey();

// Atributo pai
class Pessoa
{
    public string? Nome { get; set; }
    public string? Celular { get; set; }
    public Pessoa(string nome, string celular)
    {
        Nome = nome;
        Celular = celular;
    }
}

// Atributo filho - herda de pessoa
class Professor : Pessoa
{
    public string? Titulacao { get; set; }

    // base(nome, celular) pega os atributos 'nome' e 'celular' da classe Pai para os parâmetros do construtor
    public Professor(string nome, string titulacao, string celular) : base(nome, celular)
    {
        Titulacao = titulacao;
    }
}