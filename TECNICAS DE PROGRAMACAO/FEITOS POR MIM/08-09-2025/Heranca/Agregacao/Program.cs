Categoria cat1 = new Categoria("Material Escolar");


Produto prod1 = new Produto("Lapís Preto", 3, cat1);
Produto prod2 = new Produto("Apontador", 5, cat1);


prod1.Mostrar(prod1);
prod2.Mostrar(prod2);


class Produto
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public Categoria CategoriaProduto { get; set; }

    public Produto(string nome, double preco, Categoria categoria)
    {
        Nome = nome;
        Preco = preco;
        CategoriaProduto = categoria;
    }

    public void Mostrar(Produto prod)
    {
        Console.WriteLine($"Nome: {prod.Nome}, Preço: {prod.Preco}, Categoria: {prod.CategoriaProduto.Descritivo}");
    }
}

class Categoria
{
    public string? Descritivo { get; set; }
    public Categoria(string? descritivo)
    {
        Descritivo = descritivo;
    }
}