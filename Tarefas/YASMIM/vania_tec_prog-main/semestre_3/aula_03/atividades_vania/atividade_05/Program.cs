class Program
{
    static void Main()
    {
        var carrinho = new CarrinhoDeCompras();

        Console.WriteLine("Adicionando produtos");
        carrinho.AdicionarProduto("Televisão 200 Polegadas");
        carrinho.AdicionarProduto("Guaraná");
        carrinho.AdicionarProduto("Bobbie Goods");

        carrinho.RemoverProduto("Bobbie Goods");

        carrinho.ListarProdutos();
    }
}

// Crie uma classe CarrinhoDeCompras que armazene produtos usando ICollection<string>. Ela deve ter os métodos:

// • AdicionarProduto(string produto): adiciona um produto à coleção
// • RemoverProduto(string produto): remove um produto
// • ListarProdutos(): exibe os produtos
public class CarrinhoDeCompras
{
    ICollection<string> produtos = new List<string>();
    internal void AdicionarProduto(string produto)
    {
        produtos.Add(produto);
    }

    internal void RemoverProduto(string produto)
    {
        if (!produtos.Remove(produto))
        {
            throw new Exception($"Produto '{produto}' não foi encontrado.");
        }

        Console.WriteLine($"Produto '{produto}' foi removido!");
    }

    internal void ListarProdutos()
    {
        Console.WriteLine("--- Lita de Produtos ---");

        if (produtos.Count > 0)
        {
            foreach (string produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
        else
        {
            Console.WriteLine("O carrinho está vazio!");
        }
    }
}