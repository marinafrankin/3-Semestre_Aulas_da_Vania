
// P1 - Vania

// Lista de Exercicios

/*
 
 Atividade 1 — Manipulando Elementos

Adapte o código para que, após limpar o ArrayList (lista1.Clear()), o programa:

.Peça ao usuário que digite 5 nomes e os adicione à lista.
.Mostre todos os nomes digitados.
.Permita ao usuário remover um nome específico, informando o nome.
.Exiba novamente a lista atualizada.

 */

using System.Collections;

Console.Write("Escreva 5 nomes: ");
string nome1 = Console.ReadLine();
string nome2 = Console.ReadLine();
string nome3 = Console.ReadLine();
string nome4 = Console.ReadLine();
string nome5 = Console.ReadLine();


ArrayList lista = new ArrayList();
lista.Add(nome1);
lista.Add(nome2);
lista.Add(nome3);
lista.Add(nome4);
lista.Add(nome5);

Console.WriteLine("------------------");

Exibir(lista);

Console.WriteLine("------------------");

Console.Write("Exclua o nome: ");// o texto que exibe
var nome = Console.ReadLine();
lista.Remove(nome);

Console.WriteLine("------------------");

Exibir(lista);

static void Exibir (ArrayList lista)
{
    foreach (var nome in lista)
    {
        Console.WriteLine(nome);
    }
    Console.WriteLine("------------------");
}