Console.WriteLine("Café da manhã");

cafeDaManha();

Console.ReadKey();

static void cafeDaManha()
{
    Console.WriteLine("Preparar o café");
    var cafe = PrepararCafe();

    Console.WriteLine("\nPreparar o Pão");
    var pao = PrepararPao();

    servirCafe(cafe, pao);
};

static Cafe PrepararCafe()
{ 
    Console.WriteLine("Ferver a água");
    Thread.Sleep(200);

    Console.WriteLine("\nCoando o café");
    Thread.Sleep(2500);

    return new Cafe();
};
static Pao PrepararPao() 
{
    Console.WriteLine("\nPartir o pão");
    Thread.Sleep(2000);

    Console.WriteLine("\nPassar Manteiga no pão");
    Thread.Sleep(2000);

    Console.WriteLine("Tostar o pão");
    Thread.Sleep(2500);

    return new Pao();
};
static void servirCafe(Cafe cafe, Pao pao) 
{
    Console.WriteLine("\nServindo o café da manhã");
    Thread.Sleep(2000);

    Console.WriteLine("\nCafé servido");
};

internal class Cafe { }
internal class Pao { }
