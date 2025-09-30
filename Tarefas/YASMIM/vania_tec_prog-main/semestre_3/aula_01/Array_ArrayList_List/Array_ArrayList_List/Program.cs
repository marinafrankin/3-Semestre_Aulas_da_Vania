// Formas de criar Array

string[] nomes = new string[5] {"Ana", "Maria", "Paula", "Marcos", "Kaique"}; // especificando tamanho
int[] numeros = new int[] { 1, 2, 3 }; // sem especificar tamanho
string[] frutas = { "Maçã", "Banana", "Uva" };

for (int i = 0; i < nomes.Length; i++)
{
    Console.WriteLine(nomes[i]);
}

foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

float[] pesos = new float[2];
pesos[0] = 12.5f;

// Classes para trabalhar com Array

Array.Reverse(numeros); // inverte a ordem do array
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

Array.Sort(nomes); // organiza o array
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

int indice = Array.BinarySearch(frutas, "Uva");
Console.WriteLine(indice);

// Matrizes

int[,] numeros1 = new int[2, 3]; // duas dimensões - 2 linhas, 3 colunas
int[,,] numeros2 = new int[2, 2, 2]; // três dimensões
int[,] numeros3 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } }; // duas dimensões com valores

for (var linha = 0; linha < 2; linha++)
{
    for(var coluna = 0; coluna < 3; coluna++)
    {
        Console.WriteLine(numeros3[linha, coluna]);
    }
};

foreach(var numero in numeros3)
{
    Console.WriteLine(numero);
};

for (var linha = 0; linha < numeros3.GetLength(0); linha++) // a função GetLength[0] pega as linhas
{
    for (var coluna = 0; coluna < numeros3.GetLength(1); coluna++)  // a função GetLength[1] pega as colunas
    {
        Console.WriteLine(numeros3[linha, coluna]);
    }
};