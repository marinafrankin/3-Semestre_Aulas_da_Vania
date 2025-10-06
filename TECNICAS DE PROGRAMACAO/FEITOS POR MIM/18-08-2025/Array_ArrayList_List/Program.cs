// Formas de criar um array:

//criar e fazer atribuição:
using System.Xml;

string[] nomes = new string[5] { "Ana", "Maria", "Paula", "Marcos", "João" };

//se for nesse formato informar os numeros (se for 3 vai ser do tamanho 3)
int[] numeros = new int[] { 1, 2, 3 };


//Outra forma de criar
string[] frutas = { "Maça", "Banana", "Uva" }; 

for (int x = 0; x < 5; x++)
{
    Console.WriteLine(nomes[x]);
}

foreach (var numero in numeros)
{
    Console.WriteLine(numero);
}

float[] pesos = new float[2];
pesos[0] = 12.5f;

//classes para trabalhar com arrays
Array.Reverse(numeros); //inverte a ordem do array
foreach (var numero in numeros)
{
    Console.WriteLine(numero);
}

Array.Sort(nomes); //ordena em ordem alfabetica
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}

//O que queremos encontrar, ele trás o indice
Array.BinarySearch(frutas, "Uva"); 

Array.Sort(nomes);
foreach (var nome in nomes)
{
    Console.WriteLine(nome);
}

int indice = Array.BinarySearch(frutas, "Maça");
Console.WriteLine(indice);


// Matrizes de várias dimensões:
Console.WriteLine("Matrizes de duas dimensões:");
// Duas dimensões
int[,] numeros1; // Duas dimensões
int[,,] numeros2; // Três dimensões

int[,] numeros3 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

for(var linha = 0; linha < 2; linha++)
{
    for(var coluna = 0; coluna < 3; coluna++)
    {
        Console.WriteLine(numeros3[linha, coluna]);
    }
}

foreach(var numero in numeros3)
{
    Console.WriteLine(numero);
}

//numeros3.GetLength(0) - pega o numero de linhas;
//numeros3.GetLength(1) - pega o número de colunas;
for (var linha = 0; linha < numeros3.GetLength(0); linha++)
{
    for (var coluna = 0; coluna < numeros3.GetLength(1); coluna++)
    {
        Console.WriteLine(numeros3[linha, coluna]);
    }
}
