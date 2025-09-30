// usando List

using System.Collections.Generic;
using System.Runtime.CompilerServices;

List<string> nomes = new List<string>() { "Maria", "Pedro", "Paulo", "Roberto", "Ana" };

Console.WriteLine("----------------------");
Console.WriteLine("Lista normal\n");
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}
Console.WriteLine("----------------------");

nomes.Add("Claudia");
nomes.Insert(2, "Vera");
// nomes.RemoveAt(), nomes.Clear(), nomes.AddRange(coleção)
nomes.Sort();

Console.WriteLine("Lista Completa\n");
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}
Console.WriteLine("----------------------");

// Find (predicado), FindLast, FindIndex, FIndLastIndex, FindAll
// Preciado é uma função/método de argumento único que retorna um valor booleano
var selecionados1 = nomes.Find(Procurar);

Console.WriteLine("Nome que começa com 'P' (função Procurar)\n");
Console.WriteLine(selecionados1);
Console.WriteLine("----------------------");

static bool Procurar(string item)
{
    // return item.Contains("a");
    return item.StartsWith("P");
}

// Expressão Lambda: função anônima
Console.WriteLine("O primeiro nome que contém 'E'\n");
var resultado1 = nomes.Find(i => i.Contains('e'));
Console.WriteLine(resultado1);
Console.WriteLine("----------------------");

Console.WriteLine("Todos os nomes que iniciam com 'P'\n");
var resultado2 = nomes.FindAll(i => i.StartsWith('P'));
foreach (var item in resultado2)
{
    Console.WriteLine(item);
}
Console.WriteLine("----------------------");

Console.WriteLine("O primeiro nome que termina com 'P'\n");
var resultado3 = nomes.FindLast(i => i.Contains('P'));
Console.WriteLine("----------------------");

Console.WriteLine("O index do primeiro nome que contém 'V'\n");
var resultado4 = nomes.FindIndex(i => i.Contains("V"));
Console.WriteLine(resultado4);
Console.WriteLine("----------------------");