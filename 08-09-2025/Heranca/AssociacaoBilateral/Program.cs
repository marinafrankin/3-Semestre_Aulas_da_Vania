Produto prod = new Produto();
prod.Nome = "Caderno";
prod.Preco = 10.50;
Fornecedor forn1 = new Fornecedor("Tilibra", "11111111");
Fornecedor forn2 = new Fornecedor("Foroni", "222222222");

prod.Fornecedores = new List<Fornecedor>();
prod.Fornecedores.Add(forn2);
prod.Fornecedores.Add(forn1);


// Mostrar objeto Produto

Console.WriteLine($"Produto \nNome:{prod.Nome}, Preço:{prod.Preco}");
foreach(var fornecedor in prod.Fornecedores)
{
    Console.WriteLine($"Razão Social:{fornecedor.RazaoSocial}, Cnpj:{fornecedor.Cnpj}");
}


// Mostrar objeto Fornecedor

Fornecedor forn3 = new Fornecedor("Faber Castell", "33333333", new Produto("Lapís de Cor", 35.20));
Console.WriteLine($"Fornecedor \nRazão Social: {forn3.RazaoSocial}, Cnpj: {forn3.Cnpj}");
Console.WriteLine($"Produto -> Nome: {forn3.Produto.Nome}, Preço: {forn3.Produto.Preco}");


Console.ReadKey();


// A classe Produto está relacionada a classe Fornecedor por uma relaçao associação;
//  a multiplicidade é que um produto pode ter vários fornecedor e um fornecedor e um fornecedor;
class Produto
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public List<Fornecedor>? Fornecedores { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
    public Produto() 
    { }
}


class Fornecedor
{
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public Produto? Produto { get; set; }
    public Fornecedor(string razaoSocial, string cnpj)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
    }
    public Fornecedor(string razaoSocial, string cnpj, Produto produto)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        Produto = produto;
    }
}