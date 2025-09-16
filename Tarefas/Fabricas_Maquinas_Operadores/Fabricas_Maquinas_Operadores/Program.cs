// Marina Frankin


public class Program
{
    static async Task<async> Main(string[] args)
    {
        // 1. Instanciar os objetos necessários
        var fabrica01 = new Fabrica("Nova Era Indústria");
        var maq1 = new Maquina("Model 1", "Prensa Industrial", new DateTime(2025, 10, 25));
        var maq2 = new Maquina("Model 2", "Linha de Montagem", new DateTime(2025, 05, 12));
        var maq3 = new Maquina("Model 3", "Cortador de Precisão", new DateTime(2025, 11, 01));
        var opera1 = new Operador { Nome = "João" };
        var opera2 = new Operador { Nome = "Maria" };

        // 2. Adicionar máquinas á fábrica
        fabrica01.AdicionarMaquina(maq1);
        fabrica01.AdicionarMaquina(maq2);
        fabrica01.AdicionarMaquina(maq3);

        // 3. Executar todos os métodos
        Console.WriteLine(" Listar máquina -> ");
        fabrica01.ListarMaquinas();

        Console.WriteLine(" Buscar máquinas encontradas ->");
        var maquinaEncontrada = fabrica01.BuscarMaquinaPorModelo("Model 2");
        if (maquinaEncontrada != null)
        {
            Console.WriteLine($"Máquina encontrada: {maquinaEncontrada.Nome} - Modelo: {maquinaEncontrada.Modelo}");
        }

        Console.WriteLine(" Buscar máquinas não encontradas ->");
        var maquinaNaoEncontrada = fabrica01.BuscarMaquinaPorModelo("Model 4");
        if (maquinaNaoEncontrada == null)
        {
            Console.WriteLine("Máquina com modelo 'Model 4' não encontrada.");
        }

        Console.WriteLine(" Operando máquinas encontradas ->");
        await opera1.OperarMaquinaAsync(fabrica01, "Model 2");

        Console.WriteLine(" Operando máquinas não encontrads ->");
        await opera2.OperarMaquinaAsync(fabrica01, "Model 4");

        Console.WriteLine(" Revisão Concluida !");
    }
}

public class Equipamento 
{ 
    public string Nome { get; set; }
    public DateTime DataFabricacao { get; set; }
}


public class Maquina : Equipamento
{
    public Maquina( string modelo, string nome, DateTime dataFabricacao )
    // A class Maquina herda da class Equipamento, ela terá todas as 
    // propriedades e métodos da classe base;
    {
        Modelo = modelo;
        Nome = nome;
        DataFabricacao = dataFabricacao;
        NumeroSerie = Guid.NewGuid(); // No constrututor garante que cada nova
        //máquina tenha um identificador único, que pode ser alterado posteriormente;
    }

    public string Modelo { get; set; }
    public string HoraOperacao { get; set; }
    public Guid NumeroSerie { get; } // Somente lê
    public string Observacao { private get; set; }
    // pode ser (set), mas não pode ser lida (private get) fora da classe
    // Maquina
}


public class Fabrica
{
    public string Nome { get; set; }
    public ICollection<Maquina> Maquinas { get; set; }
    // A coleção de máquinas é do tipo "ICollection", que é uma interface para
    // listas e outros tipos de coleção;

    public Fabrica(string nome)
    {
        Nome = nome;
        Maquinas = new List<Maquina>(); // No construtor inicializa a lista
        // para que possamos adicionar máquinas a ela;
    }

    public void AdicionarMaquina(Maquina maquina)
        // Adiciona uma máquina à coleção de máquinas da fábrica;
    {
        Maquinas.Add(maquina);
    }

    public void ListarMaquinas()
        // Exibe as informações solicitadas: nome, modelo, data de fabricação
        // e número de série;
    {
        Console.WriteLine($" Máquinas na fábrica {Nome} ");
        foreach (var maquina in Maquinas)
        {
            Console.WriteLine($"Nome: {maquina.Nome}");
            Console.WriteLine($"Modelo: {maquina.Modelo}");
            Console.WriteLine($"Data de fabricação: {maquina.DataFabricacao.ToShortDateString()}");
            Console.WriteLine($"Número de série: {maquina.NumeroSerie}");
        }
    }

    public Maquina BuscarMaquinaPorModelo( string modelo )
        // para encontrar a primeira máquina
        // cujo modelo corresponde ao modelo fornecido.
        // Se uma máquina for encontrada, ela é retornada;
        // caso contrário, o método retorna null, como solicitado.
    {
        return Maquinas.FirstOrDefault(m => m.Modelo == modelo);
    }
}


public class Operador
{
    public string Nome { get; set; }
    public async Task OperarMaquinaAsync(Fabrica fabrica, string modelo)
    //  O método é assíncrono (async) e retorna um Task,
    // o que permite que a execução seja suspensa e
    // retomada sem bloquear a interface do usuário.
    {
        Console.WriteLine($"{Nome} está tentando operar a máquina modelo {modelo}...");
        await Task.Delay(2000); // Simula um tempo de carregamento;

        /*
         try-catch é usado para tratar a exceção MaquinaNaoEncontradaException.
         */
        try
        {
            var maquina = fabrica.BuscarMaquinaPorModelo(modelo);
            if(maquina == null)
            {
                throw new MaquinaNaoEncontrada($"Máquina modelo {modelo} não encontrar na Fábrica {fabrica.Nome}");
            }
            Console.WriteLine($"{Nome} agora está operando a máquina modelo {modelo}");
            await Task.Delay(3000);
        }
        catch (MaquinaNaoEncontrada mne)
        { 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mne.Message);
            Console.ResetColor();
        }
    }
}



// CLASS que será usada quando uma máquina não for encontrada.
public class MaquinaNaoEncontrada : Exception 
// A CLASS "MaquinaNaoEncontrada" herda da classe base Exception do C#
{ 
    public MaquinaNaoEncontrada() { }
    public MaquinaNaoEncontrada(string message) : base(message) { }
    public MaquinaNaoEncontrada(string message, Exception inner) : base(message, inner) { }
}