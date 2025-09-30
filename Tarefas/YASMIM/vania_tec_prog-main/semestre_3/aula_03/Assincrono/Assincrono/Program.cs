Console.WriteLine("Café da manhã");

cafeDaManha();

Console.ReadKey();

static async Task cafeDaManha()
{
    // as tasks 
    Console.WriteLine("Preparar o café");
    var taskcafe = PrepararCafe();

    Console.WriteLine("\nPreparar o Pão");
    var taskpao = PrepararPao();

    // espera as tasks tiverem resultados para enviá-los para as variaveis
    var cafe = await taskcafe;
    var pao = await taskpao;

    servirCafe(cafe, pao);
};

// Assync retorna uma TASK que vai devolver um resultado 'Cafe'
static async Task<Cafe> PrepararCafe()
{
    Console.WriteLine("Ferver a água");
    await Task.Delay(2000);

    Console.WriteLine("\nCoando o café");
    await Task.Delay(2500);

    return new Cafe();
};
static async Task<Pao> PrepararPao()
{
    Console.WriteLine("\nPartir o pão");
    await Task.Delay(2000);

    Console.WriteLine("\nPassar Manteiga no pão");
    await Task.Delay(2000);

    Console.WriteLine("Tostar o pão");
    await Task.Delay(2500);

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
