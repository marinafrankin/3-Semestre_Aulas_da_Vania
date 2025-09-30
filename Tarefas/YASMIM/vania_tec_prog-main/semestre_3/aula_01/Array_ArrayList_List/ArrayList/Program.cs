// ArrayList

using System.Collections;

ArrayList lista1 = new ArrayList() { "Maria", 25, 1.75, true};
ExibirArrayList(lista1);
var lista2 = new ArrayList();
ArrayList lista3 = new(5);

Console.WriteLine("Adicionando 55");
lista1.Add(55); // adicionando valor na ArrayList
ExibirArrayList(lista1);

Console.WriteLine("Inserindo o 2 no índice 1");
lista1.Insert(1, 2); // inserir em algum ponto do ArrayList - índice, valor
ExibirArrayList(lista1);

Console.WriteLine("Removendo no índice 3");
lista1.RemoveAt(3); // remove no índice específicado
ExibirArrayList(lista1);

string[] cores = new string[3] { "Castanho", "Branco", "Azul" };
lista1.AddRange(cores);
ExibirArrayList(lista1);

lista1.InsertRange(0, cores);
ExibirArrayList(lista1);

lista1.Clear(); // limpa o array

// mostrar elementos do ArrayList

static void ExibirArrayList(ArrayList lista1)
{
    foreach (var elemento in lista1)
    {
        Console.WriteLine(elemento);
    }

    Console.WriteLine("---------------------");
}