

/*
  
 4.	Crie uma exceção personalizada chamada PrecoInvalidoError. 
Crie uma função que cadastre um produto (nome e preço). 
Se o preço for menor ou igual a zero, lance essa exceção.

*/

try
{
    Console.Write("Digite o nome do produto: ");
    string nome = Console.ReadLine();

    Console.Write("Digite o preço do produto: ");
    double preco = Convert.ToDouble(Console.ReadLine());

    CadastrarProduto(nome, preco);
}
catch (PrecoInvalidoError e)
{
    Console.WriteLine("Erro de preço:" + e.Message);
}

catch (FormatException)
{
    Console.WriteLine("Verifique o formato");
}
finally
{
    Console.WriteLine("Fim de compra");
}

// Função ->
void CadastrarProduto(string nome, double preco)
{
    Produto produto = new Produto(nome, preco);

    Console.WriteLine("Produto cadastrado com sucesso !");
}


public class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(string nome, double preco)
    {
        if (nome.Length == 0)
        {
            throw new NomeInvalidoError("O nome é obrigatório");
        }

        if (preco <= 0)
        {
            throw new PrecoInvalidoError();
        }

        Nome = nome;
        Preco = preco;
    }
}


public class PrecoInvalidoError : Exception
{
    public PrecoInvalidoError() { }
    public PrecoInvalidoError(string message) : base(message) { }
    public PrecoInvalidoError(string message, Exception innerException) { }
}


public class NomeInvalidoError : Exception
{
    public NomeInvalidoError() { }
    public NomeInvalidoError(string message) : base(message) { }
    public NomeInvalidoError(string message, Exception innerException) { }
}