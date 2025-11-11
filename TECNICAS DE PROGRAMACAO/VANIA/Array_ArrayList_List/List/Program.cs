using System.Xml.Linq;

List <string> nomes = new List <string>(){ "Maria", "Pedro", "Paulo", "Roberto", "Ana"};

nomes.Add("Claudia");

nomes.Insert(2,"Vera");
//nomes.RemoveAt(), nomes.clear(), nomes.AddRange(coleção).........
nomes.Sort();

foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}
Console.WriteLine("-----------------------------");

//Find(Predicado), FindLast, FindIndex, FindLastIndex, FindAll
//Predicado é uma função/método de argumento único que retorna um valor booleano
var selecionados1 = nomes.Find(Procurar);
Console.WriteLine(selecionados1);

Console.WriteLine("-----------------------------");


static bool Procurar(string item)
{
    //return item.Contains("a");
    return item.StartsWith('P');
}

//expressão Lambda: é uma função anônima
var resultado1 = nomes.Find(i => i.Contains('e'));
Console.WriteLine(resultado1);
Console.WriteLine("-----------------------------");

var resultado2 = nomes.FindAll(i => i.StartsWith('P'));
foreach(var nome in resultado2)
{
    Console.WriteLine(nome);
}
Console.WriteLine("-----------------------------");

var resultado3 = nomes.FindLast(i => i.Contains("P"));
Console.WriteLine(resultado3);
Console.WriteLine("-----------------------------");

var resultado4 = nomes.FindIndex(i => i.Contains("V"));
Console.WriteLine(resultado4);
Console.WriteLine("-----------------------------");

