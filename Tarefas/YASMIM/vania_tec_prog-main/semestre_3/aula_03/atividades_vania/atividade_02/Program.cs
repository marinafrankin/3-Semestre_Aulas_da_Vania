// 2. Crie um programa que utilize ICollection<int> para armazenar números. O programa deve permitir:
ICollection<int> numeros = new List<int>();

// · Adicionar números à coleção
Console.Write("Adicione um número inteiro: ");
int num = Convert.ToInt16(Console.ReadLine());

numeros.Add(num);

Console.WriteLine("----- Lista ao adicionar ----");
exibir(numeros);

// · Remover um número específico
numeros.Remove(num);

Console.WriteLine("----- Lista ao remover ----");
exibir(numeros);

// · Mostrar a quantidade de elementos na coleção
Console.WriteLine(numeros.Count);

// · Exibir todos os números armazenados
Console.WriteLine("----- Lista final ----");
exibir(numeros);

static void exibir(ICollection<int> numeros)
{
    foreach (var numero in numeros)
    {
        Console.WriteLine(numero);
    }
}