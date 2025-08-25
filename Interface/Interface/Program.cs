IAnimal gato = new Gato();
IAnimal cao = new Cachorro();
Console.WriteLine(gato.FazerSom());
Console.WriteLine("-------------------------");
Console.WriteLine(cao.FazerSom());


Console.ReadKey();
public interface IAnimal
{
    public string FazerSom();
}

public class Gato:IAnimal
{
    public string FazerSom()
    {
        return "miau";
    }
}

public class Cachorro:IAnimal
{
    public string FazerSom()
    {
        return "auau";
    }
}