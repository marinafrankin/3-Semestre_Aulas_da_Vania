Pessoa pessoa1 = new Pessoa("Chavinho", 14, "991455876");
Pessoa pessoa2 = new Pessoa("Chavinha");

// É possível passar a pessoa para o celular de forma direta, mas não o contrário
Celular celular = new Celular(17, "995775684", pessoa2);

Console.WriteLine($"Pessoa 1\nNome: {pessoa1.Nome}");
foreach (var cel in pessoa1.Celular)
{
    Console.WriteLine($"DDD: {cel.Ddd} - Número: {cel.Numero}");
}

Console.WriteLine($"Pessoa 2\nNome: {pessoa2.Nome}");
foreach (var cel in pessoa2.Celular)
{
    Console.WriteLine($"Celular\nDDD: {cel.Ddd} - Número: {cel.Numero}");
}

class Pessoa
{
    public string? Nome { get; set; }
    public List<Celular> Celular = new List<Celular> { };

    // Construtor passando 'ddd' e 'numero' do celular
    public Pessoa(string nome, int ddd, string numero)
    {
        Nome = nome;
        Celular.Add(new Celular(ddd, numero));
    }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    // Função para adicionar celulares
    public void setCelular(int ddd, string numero) 
    {
        Celular.Add(new Celular(ddd, numero));
    }
}

class Celular
{
    public int Ddd { get; set; }
    public string Numero { get; set; }

    // Se fosse bilateral, precisaria do atributo 'DonoCelular' dentro da classe também
    public Pessoa? DonoCelular { get; set; }

    public Celular(int ddd, string numero)
    {
        Ddd = ddd;
        Numero = numero;
    }

    public Celular(int ddd, string numero, Pessoa pessoa)
    {
        Ddd = ddd;
        Numero = numero;
        DonoCelular = pessoa;
    }
}