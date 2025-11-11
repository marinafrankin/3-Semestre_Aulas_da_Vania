

/*
    2. Biblioteca

Você vai criar um pequeno sistema para registrar livros de uma 
biblioteca. Esses livros serão armazenados em uma lista e, 
em seguida, salvos em um arquivo .json no disco.

Depois, o sistema deve ler esse arquivo JSON, converter os 
dados de volta para objetos em memória e exibir os 
livros no console.

Crie uma classe Livro com as seguintes propriedades:

· Titulo (string)
· Autor (string)
· Ano (int) 

*/

using System.Text.Json;

var caminho = "arquivos.json";

List<Livro> ListaLivros = new List<Livro>
{
    new Livro{Titulo="Crônicas de Narnia", Autor="Clive Staples Lewis", Ano=1950},
    new Livro{Titulo="Harry Potter", Autor="Andrzej Sapkowski ", Ano=1993},
    new Livro{Titulo="Turma da Mõnica", Autor="Mauricio de Sousa", Ano=1963}
};

//serialização em arquivo
if (!File.Exists(caminho))
{
    string jsonString = JsonSerializer.Serialize(ListaLivros, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(caminho, jsonString);
    Console.WriteLine("Arquivo json gravado");
}

//dessserialização em arquivo
if(File.Exists(caminho))
{
    string conteudoLivro = File.ReadAllText(caminho);
    List<Livro> ListaConteudoLivro = JsonSerializer.Deserialize<List<Livro>>(conteudoLivro);
    Console.WriteLine("Lista de Livros: ");
    foreach(var Liv in ListaConteudoLivro)
    {
        Console.WriteLine($"Titulo: {Liv.Titulo}, Autor: {Liv.Autor}, Ano: {Liv.Ano}");
    }
}


public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }

    public Livro (string titulo, string autor, int ano)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
    }

    public Livro() 
    { 
        
    }
}