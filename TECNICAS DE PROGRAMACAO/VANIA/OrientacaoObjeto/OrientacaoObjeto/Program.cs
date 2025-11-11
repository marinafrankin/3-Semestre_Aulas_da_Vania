Produto p1 = new Produto("Caderno", 10.50, 50 );
Produto p2 = new ("Lápis Preto");
var p3 = new Produto();
Console.WriteLine($"{p2.Nome}\n{p2.Preco}");
Console.WriteLine("------------------------");
Console.WriteLine(p3.Preco);
Console.WriteLine("------------------------");

//p1.Nome = "Caderno";
//p1.Preco = 10.50;
//p1.Desconto = 5;
//p1.PrecoFinal = p1.Preco - (p1.Preco * p1.Desconto / 100);
//p1.EstoqueMinimo = 50;

p1.Exibir();


Console.ReadKey();
public class Produto
{
    public Produto(string nome, double Preco, int minimo)
    {
        Nome = nome;
        this.Preco = Preco;
        EstoqueMinimo = minimo;

    }
    public Produto(){}
    public Produto(string nome)
    {
        Nome = nome; 
    }
    //propriedade de leitura e gravação modificado na leitura
    private string? nome;
    public string? Nome 
    {
        get { return nome.ToUpper(); } 
        set{ nome = value; } 
    }
    //propriedade de leitura e gravação modificado na gravação
    private double preco;
    public double Preco 
    { get { return preco; }
      set 
      {
            if(value < 5.00)
            {
                preco = 5.00;
            }
            else
            {
                preco = value;
            }
      } 
    }
    //propriedade apenas de leitura
    private int desconto = 5;
    public int Desconto
    {
        get {return desconto; }
    }
    //propriedade apenas de leitura
    public double PrecoFinal 
    { 
        get {return Preco - (Preco * Desconto / 100);  }
    }
    //propriedade apenas de gravação
    private int minimo;
    public int EstoqueMinimo
    {
        set {minimo=value; }
    }

    public void Exibir()
    {
        Console.WriteLine($"{Nome}\n{Preco.ToString("c")}\n{Desconto}\n{PrecoFinal.ToString("c")}\n{minimo}");
    }
}//fim da classe
