Pessoa pes1 = new Pessoa("Carlos", 14, "99999999999");

// Mostrar dados de pes1
Pessoa pes2 = new Pessoa("Maria");
Celular cell = new Celular(17, "9888888888", pes2);

// mostrae dados de cell1

class Pessoa
{
    public string? Nome { get; set; }

    // Atalho "prop" para criar mais rápido uma publib 
    public List<Celular> Cel = new List<Celular>{};
    public Pessoa(string nome, int ddd, string numero)
    {
        Nome = nome;
        Cel.Add(new Celular(ddd, numero));
    }

    public void setCelular(int ddd, string numero)
    {
        Cel.Add(new Celular(ddd, numero));
    }

    public Pessoa(string nome)
    {
        Nome = nome;
    }
}

class Celular
{
    public int DDD { get; set; }
    public string Numero { get; set; }
    public Pessoa PessoaCelular { get; set; }


    public Celular(int ddd, string numero)
    {
        DDD = ddd;
        Numero = numero;
    }


    public Celular(int ddd, string numero, Pessoa pessoaCelular)
    {
        DDD = ddd;
        Numero = numero;
        PessoaCelular = pessoaCelular;
    }
}