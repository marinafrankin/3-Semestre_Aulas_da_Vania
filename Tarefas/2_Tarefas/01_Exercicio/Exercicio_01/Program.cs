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


Console.WriteLine("--> Salários <--");

internal interface ISalario
{
    public double Desconto { get; set; }
    public double CalcularSalario();
}

class FuncionarioMensalista : ISalario
{
    public double Desconto { get; set; }
    public double Salario { get; set; }
    public double CalcularSalario()
    {
        var salario = Salario - Desconto;
        return salario;
    }
}


class FuncionarioHorista : ISalario
{
    public double Desconto { get; set; }
    public int HorasTrabalhadas { get; set; }
    public double ValorHora { get; set; }


    public FuncionarioHorista(double desconto, int horas, double valorHora)
    {
        Desconto = desconto;
        HorasTrabalhadas = horas;
        ValorHora = valorHora;
    }


    public double CalacularSalario()
    {
        var salario = (ValorHora * HorasTrabalhadas) - Desconto;
        return salario;
    }
}

var funcionarioHorista = new FuncionarioHorista(150, 100, 2.5) { };
double salario = funcionarioHorista.CalcularSalario();

Console.WriteLine(salario);
