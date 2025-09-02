// PROGRAMAÇÃO ASSINCRONA

using System.Threading.Tasks;

Console.WriteLine("Café da Manha");
cafeDaManha();
Console.ReadKey();

static async Task cafeDaManha()
{
    Console.WriteLine("Preparar o café");
    var Taskcafe = PrepararCafe();
    Console.WriteLine("\n Preparar o pão");
    var Taskpao = PrepararPao();
    var cafe = await (Taskcafe);
    var pao = await (Taskpao);
    servirCafe(cafe, pao);
}

static async Task<Cafe> PrepararCafe()
{
    Console.WriteLine("Fever a água");
    await Task.Delay(2000);
    Console.WriteLine("\n Coando o café");
    await Task.Delay(2500);
    return new Cafe();
}

static void servirCafe(Cafe cafe, Pao pao)
{
    Console.WriteLine("\n Servindo o café da manha");
    Thread.Sleep(2000);
    Console.WriteLine("\n Café servido");
}

static async Task<Pao> PrepararPao()
{
    Console.WriteLine("\n Partir o pão");
    await Task.Delay(2000);
    Console.WriteLine("\n Passar manteiga no pão");
    await Task.Delay(2000);
    Console.WriteLine("\n Tostar o pão");
    return new Pao();
}



internal class Cafe
{
}

internal class Pao
{
}