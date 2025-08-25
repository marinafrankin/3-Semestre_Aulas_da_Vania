// Exercício 04

using System.Collections;
using System;


public string Nomes {  get; set; }
public int Idade { get; set; }


public Pessoa(string nomes, int idades)
{
    Nomes = nomes;
    Idade = idades;
}

public void Exibir()
{
    Console.WriteLine($"Nome: {Nomes}, Idade: {Idade}");
}

static void Main(string[] args)
{
    //Letra B
    ArrayList pessoas = new ArrayList();

    Console.WriteLine("Digite os dados de 3 indivíduos: ");

    for (int i = 0; i < 3; i++)
    {
        Console.Write("Nome: ");
        string nomes = Console.ReadLine();

        Console.Write("Idade: ");
        int idades = int.Parse(Console.ReadLine());

        pessoas.Add(new Pessoa(nomes, idades));
    }

    // Letra C
    Console.WriteLine("Lista inicial de pessoas: ");


    //Letra D
    pessoas.Add(new Pessoa("Jaime", 20));
    pessoas.Add(new Pessoa("Tânia", 18));

    Console.WriteLine("Lista após adicionar Jaime e Tânia: ");


    // Letra E
    pessoas.RemoveAt(pessoas.Count - 1);

    Console.WriteLine("Lista após remover o último elemento: ");


    Console.WriteLine("Fim de programa !");

}