// Tarefa 01 - 18/08/2025

// Exercicio 01
using System.Xml;

string[] frutas = { "Maça", "Banana", "Laranja", "Uva", "Manga", "Pêra", "Abacate", "Mamão", "Pêssego", "Amora" };

int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


// Letra A)
Console.WriteLine("Exercício 01");
Console.WriteLine("Letra A");
for (int x = 0; x < 10; x++)
{
    Console.WriteLine(frutas[x]);
}

foreach (var numero in numeros)
{ 
    Console.WriteLine(numero);
}

// Vai ficar em ordem alfabética;
foreach (var fruta in frutas)
{
    Console.WriteLine(fruta);
}
Console.WriteLine("----------------");

// Letra B
Console.WriteLine("Letra B");
int indice1 = Array.BinarySearch(frutas, 2);
Console.WriteLine(indice1);
Console.WriteLine("----------------");

int indice2 = Array.BinarySearch(frutas, 9);
Console.WriteLine(indice2);


// Letra C
Console.WriteLine("Letra C");

frutas[2] = "Kiwi";
frutas[9] = "Caqui";

Console.WriteLine("frutas: ");
foreach(string fruta in frutas)
{
    Console.WriteLine(fruta);
}
Console.WriteLine("----------------");


// Letra D
Console.WriteLine("Letra D");
Array.Sort(frutas);
foreach(var fruta in frutas)
{
    Console.WriteLine(fruta);
}
Console.WriteLine("----------------");