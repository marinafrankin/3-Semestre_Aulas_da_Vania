/* 2. Crie um programa que utilize ICollection<int> para armazenar números. O programa deve permitir:
        · Adicionar números à coleção
        · Remover um número específico
        · Mostrar a quantidade de elementos na coleção
        · Exibir todos os números armazenados
*/
using System;
using System.Collections.Generic;
static void ProgramaNumerico(string[] args)
{
    ICollection<int> numeros = new List<int>();

    while (true)
    {
        Console.WriteLine("---- BEMVINDO A CALCULADORA AUTOMÁTICA -----");
        Console.WriteLine("1 - Adicionar número;");
        Console.WriteLine("2 - Remover número;");
        Console.WriteLine("3 - Mostrar quantidadde de elementos;");
        Console.WriteLine("4 - Exibir todos os números;");
        Console.Write("Escolher uma opção: ");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Console.Write("Digite um número para ser adicionado: ");
                int numAdd = int.Parse(Console.ReadLine());
                numeros.Add(numAdd);
                Console.WriteLine("Número adicionado com sucessso !");
                break;


            case 2:
                Console.Write("Digite o número que deseja remover: ");
                int numRemove = int.Parse(Console.ReadLine());
                if (numeros.Remove(numRemove))
                    Console.WriteLine("Número removido com sucesso !");
                else
                    Console.WriteLine("Número não encontrado !");
                break;


            case 3:
                Console.WriteLine("Quantidade de elementos: ");
                Console.WriteLine(numeros.Count);
                break;


            case 4:
                Console.WriteLine("Números armazenados: ");
                foreach(int n in numeros)
                    Console.WriteLine(n);
                Console.WriteLine();
                break;

            case 0:
                Console.WriteLine("Obrigada por usar nossa calculadora automática, tenha um bom dia ! ");
                return;

            default:
                Console.WriteLine("Opção inválida, tente novamente ! ");
                break;
        }
    }
}