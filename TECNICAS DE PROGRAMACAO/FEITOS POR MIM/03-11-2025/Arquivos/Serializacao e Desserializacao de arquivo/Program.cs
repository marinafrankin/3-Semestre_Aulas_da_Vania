

using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
var caminho = "pessoas.json";

List<Pessoa> ListaPessoas = new List<Pessoa>
{
    new Pessoa{Nome="Ana", Idade=20},
    new Pessoa{Nome="Bella", Idade=30},
    new Pessoa{Nome="Camila", Idade=40}
};

//serialização em arquivo
if (!File.Exists(caminho))
{
    string jsonString = JsonSerializer.Serialize(ListaPessoas, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(caminho, jsonString);
    Console.WriteLine("Arquivo json gravado");
}



//dessserialização em arquivo
if(File.Exists(caminho))
{
    string conteudo = File.ReadAllText(caminho);
    List<Pessoa> ListaConteudo = JsonSerializer.Deserialize<List<Pessoa>>(conteudo);
    Console.WriteLine("Lista de Pessoas:");
    foreach(var Pes in ListaConteudo)
    {
        Console.WriteLine($"Nome: {Pes.Nome} - Idade: {Pes.Idade}");
    }
}


public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa() { } // constrututor padrão (sem argumentos) obrigatório para a desserialização

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}