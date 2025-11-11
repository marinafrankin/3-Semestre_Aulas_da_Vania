Console.WriteLine("Café da Manhã");
cafeDaManha();
Console.ReadKey();

static void cafeDaManha()
{
    Console.WriteLine("Preparar o café");
    var cafe = PrepararCafe();
    Console.WriteLine("\nPreparar o Pão");
    var pao = PrepararPao();
    servirCafe(cafe, pao);
}
static void servirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("\nServindo o café da manhã");
    Thread.Sleep(2000);
    Console.WriteLine("\nCafé servido");
}
static Cafe PrepararCafe()
{
    Console.WriteLine("Fever a água");
    Thread.Sleep(2000);
    Console.WriteLine("\nCoando o café");
    Thread.Sleep(2500);
    return new Cafe();
}
static Pao PrepararPao()
{
    Console.WriteLine("\nPartir o pão");
    Thread.Sleep(2000);
    Console.WriteLine("\nPassar Manteiga no pão");
    Thread.Sleep(2000);
    Console.WriteLine("\nTostar o pão");
    return new Pao();
}

internal class Cafe
{
}
internal class Pao
{
}



