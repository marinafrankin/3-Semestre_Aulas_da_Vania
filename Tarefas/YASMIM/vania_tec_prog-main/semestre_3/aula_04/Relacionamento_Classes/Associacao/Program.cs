Produto produto = new Produto();
produto.Nome = "Caderno";
produto.Preco = 10.50;

Fornecedor fornecedor1 = new Fornecedor("Tilibra", "1111111111");

produto.Fornecedores.Add(fornecedor1);
produto.Fornecedores.Add(new Fornecedor("Foroni", "22222222222")); // Fornecedor 2

Fornecedor fornecedor3 = new Fornecedor("Speed", "3333333333", new Produto("Ferrari", 200478.500));

// Mostrando objeto 'Produto'
Console.WriteLine("---- Produto 1 ----");
Console.WriteLine($"Nome: {produto.Nome}\nPreco: {produto.Preco}\nFornecedores");

// Mostrando array de objetos 'Fornecedores' do produto
foreach (var fornecedor in produto.Fornecedores)
{
    Console.WriteLine($"Razão Social: {fornecedor.RazaoSocial} - CNPJ: {fornecedor.Cnpj}");
}

// Mostrando objeto 'Fornecedor 3'
Console.WriteLine("\n---- Fornecedor 3 ----");
Console.WriteLine($"Razão Social: {fornecedor3.RazaoSocial} - CNPJ: {fornecedor3.Cnpj}");

// Mostrando objeto 'Produto' que está dentro de 'Fornecedor 3'
Console.WriteLine($"Nome: {fornecedor3.Produto.Nome} - Preço: {fornecedor3.Produto.Preco}");


Console.ReadKey();

// A classe 'Produto' está relacionada à classe Fornecedor por uma relação associação bilateral
// A multiplicidade é que um produto pode ter vários fornecedores e um fornecedor pode ter vários produtos
class Produto
{
    public string? Nome { get; set; }
    public double? Preco { get; set; }
    // É necessário dar 'New' para usar listas adequadamente
    public List<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();

    // Construtor vazio
    public Produto(){}

    // Construtor com parâmetros
    public Produto(string nome, double preco)
    {
        Nome = nome; 
        Preco = preco;
    }
}

class Fornecedor
{
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public Produto? Produto { get; set; }

    // Construtor sem passar o produto
    public Fornecedor(string razaosocial, string cnpj)
    {
        RazaoSocial = razaosocial;
        Cnpj = cnpj;
    }

    // Construtor passando o produto
    public Fornecedor(string razaosocial, string cnpj, Produto produto)
    {
        RazaoSocial = razaosocial;
        Cnpj = cnpj;
        Produto = produto;
    }
}