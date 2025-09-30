// Já que a categoria pode pertencer a vários produtos, pode instanciá-la fora da classe
// Caso contrário, como numa relação entre carro e motor, onde o motor pertence apenas a um carro, a instância é dentro
Categoria categoria1 = new Categoria("Material Escolar");

Produto prod1 = new Produto("Lápis Preto", 1, categoria1);
Produto prod2 = new Produto("Apontador", 5, categoria1);

// quando a função é 'static', na hora de chamá-la, utiliza-se o nome da Classe
Produto.Mostrar(prod1);
Produto.Mostrar(prod2);

class Produto
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public Categoria Categoria { get; set; }
    public Produto(string nome, double preco, Categoria categoria)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }

    public static void Mostrar(Produto produto)
    {
        Console.WriteLine($"Nome: {produto.Nome} - Preço: {produto.Preco} - Categoria: {produto.Categoria.Descritivo}");
    }
}

class Categoria
{
    public string? Descritivo { get; set; }

    public Categoria(string descritivo)
    {
        Descritivo = descritivo;
    }
}