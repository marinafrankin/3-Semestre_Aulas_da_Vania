

using System.Reflection.Metadata.Ecma335;
var pessoa = new Pessoa { Nome = "Maria", Idade = 20 };


//serializar
string json = System.Text.Json.JsonSerializer.Serialize(pessoa);
Console.WriteLine(json);


//desserialização
var jsonString = "{\"Nome\":\"João\",\"Idade\":25}";
Pessoa pessoaDess = System.Text.Json.JsonSerializer.Deserialize<Pessoa>(jsonString);
Console.WriteLine(pessoaDess.Nome);


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