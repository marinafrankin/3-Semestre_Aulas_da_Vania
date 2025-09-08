Professor prof = new Professor("Vera", "14998488890", "Mestre");


Console.WriteLine($"Nome:{prof.Nome}, Celular:{prof.Celular}, Titulação:{prof.Titulacao}");


Console.ReadKey();

// Classe Pai (classe genérica ou Pai)
// Os construtores em C# levam o nome da classe;
// Os construtores não tem retorno;
class Pessoa
{ 
    public string? Nome { get; set; }

    // Atalho "prop" para criar mais rápido uma publib 
    public string? Celular { get; set; }
    public Pessoa(string nome, string celular)
    {
        Nome = nome;
        Celular = celular;
    }
}


// Classe Filha (classe Professor herda da classe Pessoa, portanto Professor é a classe especifica ou Filha)
class Professor : Pessoa
{
    public string? Titulacao { get; set; }
    // No construtor da classe filha recebe-se todos os parâmetros(todos da classe pai e da classe filha);
    // O construtor da filha passa para o construtor do pai os parâmetros usando :base;

    // Atalho "ctor" para criar uma public dentro da class
    public Professor(string nome, string celular , string titulacao):base(nome,celular)
    {
        Titulacao = titulacao;
    }
}