

var ListaProdutos = Produto.GetProdutos();
Console.WriteLine("Produtos Eletrônicos: ");
var produtosEletronicos = ListaProdutos.Where(p => p.Categoria == "Eletrônicos");
Produto.MostrarProdutos(produtosEletronicos);


Console.WriteLine("Produtos caros no estoque: ");
var produtosCarosComEstoque = ListaProdutos.Where(p => p.Preco >= 1000 && p.Estoque > 1);
Produto.MostrarProdutos(produtosCarosComEstoque);


Console.WriteLine("Produtos caros no estoque: ");
var produtosEstoqueMinimo = ListaProdutos.Where(p => p.Estoque < 5).OrderBy(p=>p.Nome);
Produto.MostrarProdutos(produtosEstoqueMinimo);


Console.WriteLine("Produtos ordenados pro Categoria e Nome: ");
var produtosOrdenadosPorCategoriaENome = ListaProdutos.OrderBy(p => p.Categoria).ThenBy(p => p.Nome);
var CategoriaAnterior = "";
foreach (var produto in produtosOrdenadosPorCategoriaENome)
{
    if (CategoriaAnterior != produto.Categoria)
    {
        Console.WriteLine($"{produto.Categoria}");
        CategoriaAnterior = produto.Categoria;
    }
    Console.WriteLine($"{produto.Nome}");
}

Console.WriteLine("Preço menor que 500 com aumento de 10% ordenado pelo nome: ");
var precoAumento = ListaProdutos
                                .Where(p => p.Preco < 500)
                                .OrderBy(p => p.Nome)
                                .Select(p => new { NomeProduto = p.Nome.ToUpper(), 
                                                   PrecoComAumento = p.Preco * 1.1});
foreach (var produto in precoAumento)
{
    Console.WriteLine($"{produto.NomeProduto} - {produto.PrecoComAumento:c2}");
}

try
{
    var primeiro = ListaProdutos.First();
    Console.WriteLine($"Primeiro produto = {primeiro.Nome}");

    var primeiro2 = ListaProdutos.First(p => p.Nome == "Sofá");
}
catch (Exception ex)
{
    Console.WriteLine("Produto não encontrado");
}
Console.WriteLine("Utilizando FirstOrDefault");

var primeiro3 = ListaProdutos.FirstOrDefault(p => p.Nome == "Sofá");
if(primeiro3 != null)
{
    Console.WriteLine($"Primeiro produto = {primeiro3.Nome}");
}
else 
{
    Console.WriteLine("Produto não encontrado");
}

    Console.ReadKey();


public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
    public string Categoria { get; set; }


    public static List<Produto> GetProdutos()
    {
        List<Produto> produtos = new List<Produto>()
        {
            new Produto {Id=1, Nome="Camiseta", Preco=29.99, Estoque = 50, Categoria="Roupas"},
            new Produto {Id=2, Nome="Calça jeans", Preco=100.50, Estoque = 60, Categoria="Roupas"},
            new Produto {Id=3, Nome="Tênis Nike", Preco=375.60, Estoque = 40, Categoria="Calçados"},
            new Produto {Id=4, Nome="Celular", Preco=1000, Estoque = 30, Categoria="Eletrônico"},
            new Produto {Id=5, Nome="Mochila", Preco=50.99, Estoque = 20, Categoria="Acessório"},
            new Produto {Id=6, Nome="Mesa de Sala", Preco=980, Estoque = 4, Categoria="Móveis"},
            new Produto {Id=7, Nome="Smart TV LG", Preco=2500, Estoque = 2, Categoria="Eletrônico"},
        };

        return produtos;
    }

    public static void MostrarProdutos(IEnumerable<Produto> produtos)
    {
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Nome} \t {produto.Preco:c2} \t {produto.Estoque}");
        }
    }
}