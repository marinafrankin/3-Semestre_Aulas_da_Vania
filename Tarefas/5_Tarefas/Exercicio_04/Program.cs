

/*
    4. Sistema de Cadastro de Produtos
Você irá criar um sistema para cadastrar produtos. 
Toda vez que um novo produto for adicionado:
· Um evento ProdutoAdicionado deve ser disparado.

· Um método deve reagir a esse evento e gerar uma linha de 
relatório gravada com StreamWriter.

· O sistema deve permitir salvar e carregar os produtos em formato XML.

· Com LINQ, permita buscar produtos por faixa de preço ou categoria.

Requisitos:

1. Classe Produto
o Nome, Categoria, Preco, DataCadastro.

2. Classe CatalogoProdutos
o Método AdicionarProduto(Produto p) que dispara o evento.
o Lista de produtos.
o Métodos para salvar/carregar JSON.

3. Evento e Delegate
o Delegate void ProdutoHandler(Produto p).
o Evento ProdutoAdicionado.

4. Gravação de Relatórios
o Método na classe assinante para escreve relatório no 
arquivo relatorio.txt usando Stream.

5. Consultas LINQ
o Produtos com preço entre 50 e 200.
o Agrupar por categoria. 

*/


using System.Text.Json;


CatalogoProdutos catalogo = new CatalogoProdutos();
catalogo.CarregarProdutos("produtos.json");

GeradorRelatorio gerador = new GeradorRelatorio("relatorio.txt");

catalogo.ProdutoAdicionado += gerador.GerarLinhaRelatorio;

catalogo.AdicionarProduto(new Produto(
      "Notebook",
      "Eletrônicos",
      2500
));

catalogo.AdicionarProduto(new Produto(
        "Cadeira Gamer",
        "Móveis",
        2500
));

catalogo.AdicionarProduto(new Produto(
        "Soldado de borracha",
        "Brinquedo",
        60
));

Console.WriteLine("\n=== Produtos entre R$ 50 e R$ 200 ===");
var produtosFaixaPreco = catalogo.ListarProdutosEntreOsPrecos(50, 200);
foreach (var p in produtosFaixaPreco)
{
    Console.WriteLine(p.Nome);
}

Console.WriteLine("\n=== Produtos agrupados por categoria ===");
var agrupados = catalogo.Produtos.GroupBy(p => p.Categoria);
foreach (var grupo in agrupados)
{
    Console.WriteLine($"\nCategoria: {grupo.Key}");
    foreach (var p in grupo)
    {
        Console.WriteLine($"  - {p.Nome} - R$ {p.Preco:F2}");
    }
}



public delegate void ProdutoHandler(Produto p);

public class Produto
{
    public string? Nome { get; set; }
    public string? Categoria { get; set; }
    public double Preco { get; set; }
    public DateTime DataCadastro { get; set; }

    public Produto(string? nome,  string categoria, double preco)
    {
        Nome = nome;
        Categoria = categoria;
        Preco = preco;
        DataCadastro = DateTime.Now;
    }
}



public class CatalogoProdutos
{
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    private string? CaminhoArquivo;

    public event ProdutoHandler? ProdutoAdicionado;

    public void CarregarProdutos(string caminhoArquivo)
    {
        CaminhoArquivo = caminhoArquivo;

        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo não encontrado, criando um novo arquivo:" + caminhoArquivo);
            File.WriteAllText(caminhoArquivo, "[]");
            return;
        }

        try
        {
            string json = File.ReadAllText(caminhoArquivo);

            var lista = JsonSerializer.Deserialize<List<Produto>>(json);

            if (lista != null) Produtos = lista;
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Erro ao carregar produtos: " + ex.Message);
        }
    }


    public void AdicionarProduto(Produto p)
    {
        Produtos.Add(p);

        ProdutoAdicionado?.Invoke(p);

        if (CaminhoArquivo != null)
            SalvarProdutos(CaminhoArquivo);
    }


    public void SalvarProdutos(string caminhoArquivo)
    {
        try
        {
            string json = JsonSerializer.Serialize(Produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao salvar proutos: " + ex.Message);
        }
    }


    public void ListarProdutos()
    {
        foreach (var item in Produtos)
        {
            Console.WriteLine(item);
        }
    }


    public List<Produto> ListarProdutosPorCategoria(string categoria)
    {
        return Produtos.Where(p => p.Categoria == categoria).ToList();
    }


    public List<Produto> ListarProdutosEntreOsPrecos(int precoInicial, int precoFinal)
    {
        return Produtos.Where(p => p.Preco >= precoInicial && p.Preco <= precoFinal).ToList();
    }
}



public class GeradorRelatorio
{
    private string CaminhoRelatorio;

    public GeradorRelatorio(string caminhoRelatorio)
    {
        CaminhoRelatorio = caminhoRelatorio;
    }


    public void GerarLinhaRelatorio(Produto p)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(CaminhoRelatorio, true))
            {
                string linha = $"{DateTime.Now: dd/MM/yyyy HH:mm:ss} - Produto Adicionado: {p.Nome} | Categoria: {p.Categoria} | Preço: R$ {p.Preco:F2} | Data Cadastro: {p.DataCadastro:dd/MM/yyyy}";
                writer.WriteLine(linha);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Erro em garvar relatorio: ");
        }
    }
}