

/* 
    5. Sistema de Registro de Ocorrências


Você irá criar um sistema que registra ocorrências de incidentes em um 
condomínio. Toda vez que uma ocorrência for registrada:

· O evento OcorrenciaRegistrada deve ser disparado.
· Ouvintes(assinantes) devem reagir de formas diferentes:
o Um grava no log ocorrencias.txt.
o Outro exibe no console.
o Se a ocorrência for urgente, exibir " ALERTA URGENTE “ no console.
· As ocorrências devem ser salvas em formato JSON.
· O sistema deve permitir buscar ocorrências por tipo ou urgência com LINQ.

Requisitos:

1. Classe Ocorrencia
o Tipo, Local, Data, Urgente (bool).

2. Classe CentralDeOcorrencias
o Método Registrar(Ocorrencia o) que dispara o evento.
o Lista de ocorrências.
o Métodos para salvar/carregar em JSON.

3. Evento e Delegate
o Delegate void OcorrenciaHandler(Ocorrencia o).
o Evento OcorrenciaRegistrada.

4. Ouvintes(assinantes)
o Um grava no arquivo.
o Outro escreve alertas no console.
o Condicional especial para Urgente igual a true.

5. Consultas LINQ
o Filtrar ocorrências urgentes.
o Agrupar por tipo.

*/



using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;



CentralDeOcorrencias centralOcorrencias = new CentralDeOcorrencias();

centralOcorrencias.OcorrenciaRegistrada += OcorrenciaOuvintes.GravarLog;
centralOcorrencias.OcorrenciaRegistrada += OcorrenciaOuvintes.ExibirAlertasConsole;

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n--- Menu de Ocorrências ---");
    Console.WriteLine("1. Registrar Ocorrência");
    Console.WriteLine("2. Listar todas as ocorrências");
    Console.WriteLine("3. Filtrar ocorrências urgentes");
    Console.WriteLine("4. Agrupar ocorrências por tipo");
    Console.WriteLine("5. Salvar ocorrências em JSON");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();

            Console.Write("Local: ");
            string local = Console.ReadLine();

            Console.Write("Urgente? (y/n) ");
            string ehUrgente = Console.ReadLine().ToLower();
            bool urgente = false;

            if (ehUrgente == "y")
            {
                urgente = true;
            }

            var novaOcorrencia = new Ocorrencia(tipo, local, urgente);
            centralOcorrencias.Registrar(novaOcorrencia);
            break;

        case "2":
            Console.Clear();
            Console.WriteLine($"--- Lista de Ocorrências ---");

            centralOcorrencias.ListarOcorrencias();
            break;

        case "3":
            var urgentes = centralOcorrencias.Ocorrencias.Where(o => o.Urgente == true).ToList();

            Console.Clear();
            Console.WriteLine("--- Ocorrências Urgentes ---");

            if (urgentes.Count() == 0)
            {
                Console.WriteLine("\nNenhuma ocorrência urgente registrada!");
            }
            else
            {
                centralOcorrencias.ListarOcorrenciasFiltradas(urgentes);
            }

            break;

        case "4":
            var gruposPorTipo = centralOcorrencias.Ocorrencias.GroupBy(o => o.Tipo).ToList();

            Console.Clear();
            Console.WriteLine("--- Ocorrências Urgentes ---");

            if (centralOcorrencias.Ocorrencias.Count == 0)
            {
                Console.WriteLine("\nNenhuma ocorrência registrada!");
            }

            foreach (var grupo in gruposPorTipo)
            {
                var grupoTipo = grupo.FirstOrDefault()?.Tipo;

                Console.WriteLine($"\n[Tipo: {grupoTipo}]");

                foreach (var ocorrencia in grupo)
                {
                    Console.WriteLine($" - {ocorrencia.Local} ({ocorrencia.Data})");
                }
            }
            break;

        case "5":
            Console.Clear();
            centralOcorrencias.SalvarJson();
            Console.WriteLine("\nUsuários salvos em ocorrencias.json");
            break;

        case "6":
            Console.WriteLine("Saindo...");
            continuar = false;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            break;
    }
}




public delegate void OcorrenciaHandler(Ocorrencia o);


public class Ocorrencia
{
    public string Tipo { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public bool Urgente { get; set; } = false; // bool é quando é false ou true

    public Ocorrencia() { }

    public Ocorrencia(string tipo, string local, bool urgente)
    {
        Tipo = tipo;
        Local = local;
        Urgente = urgente;
        Data = DateTime.Now;
    }
}


public class CentralDeOcorrencias
{
    public event OcorrenciaHandler OcorrenciaRegistrada;
    public List<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();

    public CentralDeOcorrencias()
    {
        CarregarJson();
    }

    public void Registrar(Ocorrencia o)
    {
        if (o == null) return;

        Ocorrencias.Add(o);
        OcorrenciaRegistrada.Invoke(o); // ele dispara esse evento, nesse exemplo
    }

    public void SalvarJson()
    {
        if (Ocorrencias.Count == 0) return;

        string caminho = "ocorrencias.json";

        string jsonString = JsonSerializer.Serialize(Ocorrencias, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        });

        File.WriteAllText(caminho, jsonString);
    }

    public void CarregarJson()
    {
        string caminho = "ocorrencias.json";

        if (File.Exists(caminho))
        {
            string conteudoJson = File.ReadAllText(caminho);
            var users = JsonSerializer.Deserialize<List<Ocorrencia>>(conteudoJson);

            if (users != null)
            {
                Ocorrencias.AddRange(users);
            }
        }
    }

    public void ListarOcorrencias()
    {
        if (Ocorrencias.Count == 0)
        {
            Console.WriteLine("\nNenhuma ocorrência registrada!");
            return;
        }

        foreach (var ocorrencia in Ocorrencias)
        {
            string urgencia = string.Empty;

            if (ocorrencia.Urgente) urgencia = "Sim"; else urgencia = "Não";

            Console.WriteLine($"\nTipo: {ocorrencia.Tipo}");
            Console.WriteLine($"Local: {ocorrencia.Local}");
            Console.WriteLine($"Urgente: {urgencia}");
            Console.WriteLine($"Data de Registro: {ocorrencia.Data}"); ;
        }
    }

    public void ListarOcorrenciasFiltradas(List<Ocorrencia> ocorrencias)
    {
        if (Ocorrencias.Count == 0)
        {
            Console.WriteLine("\nNenhuma ocorrência registrada!");
            return;
        }

        foreach (var ocorrencia in ocorrencias)
        {
            string urgencia = string.Empty;

            if (ocorrencia.Urgente) urgencia = "Sim"; else urgencia = "Não";

            Console.WriteLine($"Tipo: {ocorrencia.Tipo}");
            Console.WriteLine($"Local: {ocorrencia.Local}");
            Console.WriteLine($"Urgente: {urgencia}");
            Console.WriteLine($"Data de Registro: {ocorrencia.Data}\n");
        }
    }
}



public static class OcorrenciaOuvintes
{
    public static void GravarLog(Ocorrencia o)
    {
        var caminho = "ocorrencia.txt";
        var mensagem = $"Nova ocorrencia do tipo [{o.Tipo}] em {o.Local}, registrada em: {o.Data}";

        if (!File.Exists(caminho))
        {
            File.WriteAllText(caminho, mensagem);
            return;
        }
        File.AppendAllText(caminho, mensagem);
    }


    public static void ExibirAlertasConsole(Ocorrencia o)
    {
        Console.Clear();

        if (o.Urgente)
        {
            Console.WriteLine("ALERTA URGENTE");
        }

        Console.WriteLine("Nova ocorrencia registrada:");
        Console.WriteLine($"Tipo: {o.Tipo}");
        Console.WriteLine($"Localização: {o.Local}");
        Console.WriteLine($"Data: {o.Data}");
    }
}