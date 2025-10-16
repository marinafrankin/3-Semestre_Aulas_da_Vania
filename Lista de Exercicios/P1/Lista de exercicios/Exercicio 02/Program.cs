
/*

    2.	Simula o cadastro de um produto com tratamento para entrada 
inválida e exceções genéricas. Lidar com entrada do usuário, 
múltiplos catch, e validação de regra de negócio. (FormatException e outros).

*/


try 
{
    
    Console.Write("Digite o nome do produto: ");
    string nomeProd = Console.ReadLine();

    Console.Write("Digite a descrição do produto: ");
    string descricaoProd = Console.ReadLine();

    Console.Write("Digite o preço do produto: ");
    double precoProd = Convert.ToDouble(Console.ReadLine());

    Console.Write("Digite a quantidade do produto: ");
    int quantidadeProd = Convert.ToInt32(Console.ReadLine());

    Produtos produtos = new Produtos(nomeProd, descricaoProd, precoProd, quantidadeProd);

    produtos.Exibir();
}
catch(FormatException)
{
    Console.WriteLine("Verifique o formato");
}

catch (OverflowException)
{
    Console.WriteLine("Digite um número 1 até 9999");
}

catch (Exception e)
{
    Console.WriteLine(e.Message);
}

finally
{
    Console.WriteLine("Fim de operação");
}

class Produtos
{ 
    public string Nome {  get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }


    public Produtos (string nome, string descricao, double preco, int quantidade)
    {
        // Regras de negócio:
        if (nome.Length == 0) 
        {
            throw new Exception("O nome é obrigatória");
        }
        if (nome.All(char.IsDigit))
        {
            throw new Exception("O nome não pode ser apenas números");
        }


        if (descricao.Length == 0)
        {
            throw new Exception("A descricao é obrigatória");
        }
        if (descricao.All(char.IsDigit))
        {
            throw new Exception("A descricao não pode ter apenas números");
        }


        if (quantidade <= 0)
        {
            throw new Exception("A quantidade deve ser maior do que 0");
        }


        if (preco <= 0)
        {
            throw new Exception("O preço deve ser maior que 0");
        }


        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Quantidade = quantidade;
    }

    public void Exibir()
    {
        Console.WriteLine($"Produto: {Nome}, {Descricao}");
        Console.WriteLine($"Preço: {Preco} e Quantidade: {Quantidade}");
    }
}
