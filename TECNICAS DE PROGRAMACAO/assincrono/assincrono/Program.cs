using System.Threading.Tasks;

Console.WriteLine("Café da Manhã");
cafeDaManha();
Console.ReadKey();

static async Task cafeDaManha()
{
    Console.WriteLine("Preparar o café");
    var Taskcafe = PrepararCafe();
    Console.WriteLine("\nPreparar o Pão");
    var Taskpao = PrepararPao();
    var cafe = await (Taskcafe);
    var pao = await (Taskpao);
    servirCafe(cafe, pao);
}
static void servirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("\nServindo o café da manhã");
    Thread.Sleep(2000);
    Console.WriteLine("\nCafé servido");
}
static async Task<Cafe> PrepararCafe()
{
    Console.WriteLine("Fever a água");
    await Task.Delay(2000);
    Console.WriteLine("\nCoando o café");
    await Task.Delay(2500);
    return new Cafe();
}
static async Task<Pao> PrepararPao()
{
    Console.WriteLine("\nPartir o pão");
    await Task.Delay(2000);
    Console.WriteLine("\nPassar Manteiga no pão");
    await Task.Delay(2000);
    Console.WriteLine("\nTostar o pão");
    return new Pao();
}

internal class Cafe
{
}
internal class Pao
{
}



