// Exercício 02 
using System;

// Letra A)
Console.Write("Escreva a quantidade de números que preferir: ");
int tamanho = int.Parse(Console.ReadLine());


// Letra B)
int[] numeros = new int[tamanho];

for (int x = 0; x < numeros.Length; x++)
{
    Console.Write($"Digite um valor para a posição do {x}: ");
    numeros[x] = int.Parse(Console.ReadLine());
}

string inicial;


// Letra E)
do
{
    Console.Write("Digite um número para procurar se existe ou não no array: ");
    inicial = Console.ReadLine();

    if (inicial.ToLower() != "Não existe")
    {

        // Letra C
        int procurar = int.Parse(inicial);
        bool encontrado = false;

        for (int x = 0; x < numeros.Length; x++)
        {
            if (numeros[x] == procurar)
            {
                encontrado = true; 
                break;
            }
        }


        // Letra D
        if (encontrado)
            Console.WriteLine($"O número {procurar} existe no array !");
        else
            Console.WriteLine($"O número {procurar} não existe no array !");
    }

} while (inicial.ToLower() != "Não existe");

Console.WriteLine("Fim !");

