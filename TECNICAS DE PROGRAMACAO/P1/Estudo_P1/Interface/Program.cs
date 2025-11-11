

/*
    INTERFACE 

    Exercício:
    Crie uma interface chamada IVeiculo que contenha:
        .Um método Ligar().
        .Um método Desligar().

    Depois, crie duas classes que implementem essa interface:
        .Carro
        .Moto

    Cada uma deve exibir mensagens diferentes ao ligar e desligar.

*/

Carro carro = new Carro();
Moto moto = new Moto();


Console.WriteLine(carro.Ligar());
Console.WriteLine("--------------------");
Console.WriteLine(carro.Desligar());

Console.WriteLine("\n--------------------");
Console.WriteLine(moto.Ligar());
Console.WriteLine("--------------------");
Console.WriteLine(moto.Desligar());

Console.ReadKey();

public interface IVeiculo
{
    public string Ligar();

    public string Desligar();
}

public class Carro:IVeiculo
{
    public string Ligar()
    {
        return "Carro automatico sendo ligago";
    }

    public string Desligar()
    {
        return "Carro automático desligando";
    }
}

public class Moto:IVeiculo
{
    public string Ligar()
    {
        return "Moto industrial sendo ligago";
    }

    public string Desligar()
    {
        return "Moto industrial desligando";
    }
}

/*
 using System.Collections;

Carro carro = new Carro();
Moto moto = new Moto();

carro.Ligar();
moto.Desligar();

// Início da Atividade - Interface
    // Crie uma interface chamada IVeiculo que contenha:
    // Um método Ligar()
    // Um método Desligar()
    public interface IVeiculo
    {
        public void Ligar();
        public void Desligar();
    }

    // Depois, crie duas classes que implementem essa interface:
    // Cada uma deve exibir mensagens diferentes ao ligar e desligar.

    // Carro
    public class Carro : IVeiculo
    {
        public bool Status { get; set; } = false;
        public void Ligar()
        {
            if (Status == false) 
            {
                Console.WriteLine("Ligando o carro...");
                Status = true;
            }
            else
            {
                Console.WriteLine("O carro já está ligado!");
            }
        }

        public void Desligar()
        {
            if (Status == true)
            {
                Console.WriteLine("Desligando o carro...");
                Status = false;
            }
            else
            {
                Console.WriteLine("O carro já está desligado!");
            }
        }
    }

    // Moto
    public class Moto : IVeiculo
    {
        public bool Status { get; set; } = false;
        public void Ligar()
        {
            if (Status == false)
            {
                Console.WriteLine("Ligando a moto...");
                Status = true;
            }
            else
            {
                Console.WriteLine("A moto já está ligada!");
            }
        }

        public void Desligar()
        {
            if (Status == true)
            {
                Console.WriteLine("Desligando a moto...");
                Status = false;
            }
            else
            {
                Console.WriteLine("A moto já está desligada!");
            }
        }
}
// Fim da Atividade
 
*/