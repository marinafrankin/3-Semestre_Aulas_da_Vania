/*
    5. Crie uma classe CarrinhoDeCompras que armazene produtos 
usando ICollection<string>. 
Ela deve ter os métodos:
· AdicionarProduto(string produto): adiciona um produto à coleção
· RemoverProduto(string produto): remove um produto
· ListarProdutos(): exibe os produtos 
*/

using System;
using System.Collections.Generic;

public class CarrinhoCompras
{
    private ICollection<string> produtos;


    private CarrinhoCompras() 
    { 
        this.produtos = new List<string>();
    }

    public void AdicionarProduto(string produto)
    {
        if(!string.IsNullOrWhiteSpace(produto))
        {
            produtos.Add(produto);
            Console.WriteLine($"'{produto}' foi adicionado ao carrinho com sucesso ! ");
        }
    }


    public void RemoverProduto(string produto)
    {
        if (produto.Remove(produto))
        {
            Console.WriteLine($"'{produto}' foi removido com sucesso ! ");
        }
        else 
        { 
            Console.WriteLine($"Não foi possível remover '{produto}' do carrinho ! ");
        }
    }


    public void ListarProdutos()
    { 
        Console.WriteLine("--> Produtos <--");
        if (produtos.Count == 0)
        { 
            Console.WriteLine("O carrinho está vazio ! ");
        }
        else 
        {
            foreach (var item in produtos)
            {
                Console.WriteLine($"- {item}");
            }
        }
        Console.WriteLine("------------------------------");
    }
}


public class Program
{
    public static void Main()
    {
        CarrinhoCompras meuCarrinho = new CarrinhoCompras();

        meuCarrinho.AdicionarProduto("Caderno de desenho");
        meuCarrinho.AdicionarProduto("Lapis de cor");
        meuCarrinho.AdicionarProduto("Borracha");

        meuCarrinho.ListarProdutos();

        meuCarrinho.RemoverProduto("Borracha");

        meuCarrinho.ListarProdutos();

    }
}