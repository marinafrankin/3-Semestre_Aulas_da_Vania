// PROGRAMÇÃO SINCRONA

using System.Reflection;

Console.WriteLine("Café da Manha");
cafeDaManha();
Console.ReadKey();

static void cafeDaManha()
{
    Console.WriteLine("Preparar o café");
    var cafe = PrepararCafe();
    Console.WriteLine("\n Preparar o pão");
    var pao = PrepararPao();
    servirCafe(cafe, pao);
}

static Cafe PrepararCafe()
{
    Console.WriteLine("Fever a água");
    Thread.Sleep(2000);
    Console.WriteLine("\n Coando o café");
    Thread.Sleep(2500);
    return new Cafe();
}

static void servirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("\n Servindo o café da manha");
    Thread.Sleep(2000);
    Console.WriteLine("\n Café servido");
}

static Pao PrepararPao()
{
    Console.WriteLine("\n Partir o pão");
    Thread.Sleep(2000);
    Console.WriteLine("\n Passar manteiga no pão");
    Thread.Sleep(2000);
    Console.WriteLine("\n Tostar o pão");
    return new Pao();
}



internal class Cafe
{
}

internal class Pao
{
}