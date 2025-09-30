// instanciando usando o construtor completo 
Produto produto1 = new Produto("Caderno", 10.50, 50);

// instanciando usando o construtor vazio
Produto produto2 = new();

// instanciando usando o construtor de apenas nome
var produto3 = new Produto("Lápis");

produto1.Nome = "Caderno";
produto1.Preco = 10.50;
// produto1.Desconto = 5;
// produto1.PrecoFinal = produto1.Preco - (produto1.Preco * produto1.Desconto / 100); 
produto1.EstoqueMinimo = 50;
produto1.Exibir();

Console.ReadKey();

public class Produto
{
    // Construtor com valores
    public Produto(string Nome, double preco, int estoqueMin)
    {
        // é necessário do THIS quando o atributo possui a mesma grafia
        this.Nome = Nome;

        // caso a grafia seja diferente, é necessário apenas gravar
        Preco = preco;
        EstoqueMinimo = estoqueMin;

    }

    // Construtor vazio
    public Produto() { }

    // Construtor apenas usando o nome
    public Produto(string nome) 
    { 
        Nome = nome;
    }

    public string? Id { get; set; }

    // propriedade de leitura e gravação, modificando atributo NOME na leitura
    private string? nome;
    public string? Nome 
    {
        get { return nome.ToUpper(); }
        set { nome = value; } 
    }

    // propriedade de leitura e gravação, colocando condições no resultado do valor PREÇO
    private double preco;
    public double Preco 
    {
        get { return preco; }
        set 
        { 
            if (value < 5.00)
            {
                preco = 5.00;
            }
            else
            {
                preco = value;
            }
        } 
    }

    // propriedade de apenas leitura, com valor fixo no desconto
    private int desconto = 5;
    public int Desconto 
    {
        get { return desconto; }
    }
    public double PrecoFinal 
    {
        get { return Preco - (Preco * Desconto / 100); } 
    }

    // propriedade apenas de gravação, nome do privado não necessariamente precisa ser o mesmo nome do atributo
    private int minimo;
    public int EstoqueMinimo 
    { 
        set { minimo = value; } 
    }

    public void Exibir()
    {

        Console.WriteLine($"{Nome}\n "+ $"{Preco.ToString("c")}\n{Desconto}\n" + $"{PrecoFinal.ToString("c")}\n" + $"{minimo}"); // É usado o atributo privado quando o atributo principal é apenas gravação
    }
};

