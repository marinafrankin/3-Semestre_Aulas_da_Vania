IAnimal gato = new Gato();
IAnimal cachorro = new Cachorro();

gato.ExibirCor();

public interface ICor
{
    public void ExibirCor();
}

public interface IAnimal : ICor
{
    public string FazerSom();
}

public class Gato : IAnimal
{
    public string Cor { get; set; }
    public string FazerSom() 
    {
        return "Miau";   
    }

    public void ExibirCor()
    {
        Console.Write("Escreva a cor do animal: ");
        Cor = Console.ReadLine();

        Console.Write($"Cor do animal: {Cor}");
    }
}

public class Cachorro : IAnimal
{
    public string FazerSom()
    {
        return "Au Au";
    }

    public void ExibirCor()
    {
        Console.WriteLine("Preto");
    }
}

