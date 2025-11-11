

/*
 
5.	Crie uma função chamada vender_produto que recebe 
dois argumentos:
•	quantidade_disponivel (int)
•	quantidade_vendida (int)
Se a quantidade_vendida for maior que a 
quantidade_disponivel "Quantidade indisponível em estoque."
No programa principal, trate esse erro com try/catch.
 
*/

try
{
    Console.Write("Digite o nome do produto: ");
    string nome = Console.ReadLine();

    Console.Write("Digite o preço do produto: ");
    double preco = Convert.ToDouble(Console.ReadLine());

    Console.Write("Digite a quantidade disponível: ");
    int quantidade_disponivel = Convert.ToInt32(Console.ReadLine());

    Console.Write("Digite a quantidade disponível: ");
    int quantidade_vendida = Convert.ToInt32(Console.ReadLine());

    vender_produto(nome, preco, quantidade_disponivel, quantidade_vendida);
}
catch (ProdutoInsuficienteException e)
{
    Console.WriteLine("Erro de preço:" + e.Message);
}

catch (FormatException)
{
    Console.WriteLine("Verifique o formato");
}
finally
{
    Console.WriteLine("Fim de verificação de estoque ");
}

void vender_produto(string nome, double preco, int quantidade_disponivel, int quantidade_vendida)
{
    Produto produto = new Produto(nome, preco, quantidade_disponivel, quantidade_vendida);

    Console.WriteLine("Verificação de estoque com sucesso !");
}

public class Produto 
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade_disponivel { get; set; }
    public int Quantidade_vendida { get; set; }

    public Produto(string nome, double preco, int quantidade_disponivel, int quantidade_vendida)
    {
        if (nome.Length == 0)
        {
            throw new NomeInvalidoError("O nome é obrigatório");
        }

        if (preco <= 0)
        {
            throw new ProdutoInsuficienteException();
        }

        if (quantidade_vendida > quantidade_disponivel)
        {
            throw new ProdutoInsuficienteException(" Quantidade indiponível em estoque ");
        }

        Nome = nome;
        Preco = preco;
        Quantidade_disponivel = quantidade_disponivel;
        Quantidade_vendida = quantidade_vendida;
    }
}

public class ProdutoInsuficienteException : Exception
{
    public ProdutoInsuficienteException() { }
    public ProdutoInsuficienteException(string message) : base(message) { }
    public ProdutoInsuficienteException(string message, Exception innerException) { }
}

public class NomeInvalidoError : Exception
{
    public NomeInvalidoError() { }
    public NomeInvalidoError(string message) : base(message) { }
    public NomeInvalidoError(string message, Exception innerException) { }
}


/*
    OU 

try
{
    Console.Write("Digite o nome do produto: ");
    string nomeProduto = Console.ReadLine();

    Console.Write("Digite o preço do produto: ");
    double precoProduto = Convert.ToDouble(Console.ReadLine());

    Produto produto = new Produto(nomeProduto, precoProduto);

    Console.Write("Digite a quantidade disponível do produto: ");
    int qtdDisponivel = Convert.ToInt32(Console.ReadLine());

    Console.Write("Digite a quantidade vendida do produto: ");
    int qtdVendida = Convert.ToInt32(Console.ReadLine());

    produto.VenderProduto(qtdDisponivel, qtdVendida);
    produto.Exibir();
}
catch (FormatException)
{
    Console.WriteLine("Por favor, verifique o formato!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


    class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeVendida { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public void VenderProduto(int qtdDisponivel, int qtdVendida)
        {
            if (qtdDisponivel < qtdVendida) throw new Exception("Quantidade indisponível no estoque!");

            Console.WriteLine("\nProduto vendido!");

            QuantidadeDisponivel = qtdDisponivel;
            QuantidadeVendida = qtdVendida;
        }

        public void Exibir()
        {
            Console.WriteLine($"\nProduto: {Nome}");
            Console.WriteLine($"Preço: R${Preco}");
            Console.WriteLine($"Quantidade Disponível: {QuantidadeDisponivel}");
            Console.WriteLine($"Quantidade Vendida: {QuantidadeVendida}");
        }
    }

*/