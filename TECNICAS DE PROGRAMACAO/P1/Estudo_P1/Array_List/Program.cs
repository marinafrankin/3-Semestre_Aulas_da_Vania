
/*
 Atividade 2 — Trabalhando com AddRange e InsertRange

Ainda usando o mesmo código base:

.Crie um novo vetor de strings chamado animais contendo três nomes de animais.
.Use AddRange() para adicionar esses elementos ao final de lista1.
.Depois, use InsertRange() para inserir novamente o mesmo vetor no início da lista.
.Exiba o resultado com ExibirArrayList(lista1).
 */

using System.Collections;

ArrayList lista = new ArrayList();

string[] animais1 = new string[3]
{ "Zebra", "Elefante", "Avetruz" };

string[] animais2 = new string[3]
{ "Leao", "Macaco", "Cobra" };

lista.AddRange(animais1); // adiciona no final da lista

lista.InsertRange(0, animais2); // vc escolhe onde vai ser inserido na lista, como no inicio da lista

lista.Insert(1, "Rato");

Exibir(lista);

lista.Clear();

Exibir(lista);

static void Exibir(ArrayList lista)
{
    foreach (var elemento in lista)
    {
        Console.WriteLine(elemento);
    }
}