// Exercicio 01

/*
  1. Criar uma interface chamada ISalario que tenha um método:
    · double CalcularSalario();
    a. Criar duas classes que implementem a interface:
    · FuncionarioHorista: salário baseado em horas trabalhadas e valor por hora.
    · FuncionarioMensalista: salário fixo mensal.

    b. Criar um programa principal que instancie diferentes tipos de funcionários e exiba seus salários. 
*/

// ISalario

Console.WriteLine("Salários");
Console.ReadKey();

static void CalcularSalario()
{
    Console.WriteLine("");
    var cafe = FuncionarioHorista();
    Console.WriteLine("\n Salário a hora");
    var pao = FuncionarioMensalista();
    diferencaSalrios(horas, mensalidade);
}

static Horas FuncionarioHorista()
{
    Console.WriteLine("Salário de horas trabalhadas: ");
    Thread.Sleep(2000);
    Console.WriteLine("Valor a hora: ");
    Thread.Sleep(2500);
    return new Horas();
}

static void diferencaSalrios(Horas horas, Mensalidade mensalidade)
{
    Console.WriteLine("Salário por hora: ");
    Thread.Sleep(2000);
    Console.WriteLine("Salário fixo mensal: ");
}

static Mensalidade FuncionarioMensalista()
{
    Console.WriteLine("Salário fixo mensal: ");
    Thread.Sleep(2000);
    return new Mensalidade();
}



internal class Horas
{
}

internal class Mensalidade
{
}