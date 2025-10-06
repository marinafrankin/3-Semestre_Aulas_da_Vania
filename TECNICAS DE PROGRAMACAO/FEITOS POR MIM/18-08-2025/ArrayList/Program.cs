// As declarações de ArrayList:

using System.Collections;

ArrayList lista1 = new ArrayList() { "Maria", 25, 1.75, true };
ExibirArrayList(lista1);

var lista2 = new ArrayList();

ArrayList lista3 = new(5);

lista1.Add(55);
ExibirArrayList(lista1);
lista1.Insert(1, 2);
ExibirArrayList(lista1);
// lista1.Clear();
lista1.RemoveAt(3);
ExibirArrayList(lista1);

string[] cores = new string[3] { "Castanho", "Verdes", "Branca" };

lista1.AddRange(cores);
ExibirArrayList(lista1);
lista1.InsertRange(0, cores);
ExibirArrayList(lista1);

lista1.Clear();
ExibirArrayList(lista1);


// Mostrar elementos do arrayList:
static void ExibirArrayList(ArrayList lista1)
{
    foreach(var elemento in lista1)
    {
        Console.WriteLine(elemento);
    }
    Console.WriteLine("-----------------------------------------");
}