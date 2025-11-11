

/*
 
    1. Consumo de energia

Neste exercício, você irá simular o consumo 
de energia elétrica de diferentes dispositivos em uma casa 
(como ar-condicionado, geladeira, computador, 
chuveiro, ferro de passar roupa, etc).

Cada dispositivo elétrico consumirá uma quantidade de 
energia sempre que for utilizado. 
O consumo de todos os dispositivos será somado para gerar 
o consumo total da casa.

Quando o consumo total ultrapassar um valor limite 
(ex: 1000 Watts), o sistema deverá disparar um evento 
chamado ConsumoElevado.

Esse evento será baseado em um delegate personalizado, 
que envia informações sobre:

· O nome do dispositivo que causou o excesso (o de maior consumo).
· O consumo total atual da casa.

Crie classe assinante (que recebem a notificação do evento) 
deverá tomar uma ação automática, como:

· Exibir um alerta no console.
· Simular o desligamento de alguns dispositivos 
(ex: ar-condicionado ou aquecedor).

Requisitos Técnicos:

1. Classe DispositivoEletrico
o Propriedades: Nome, ConsumoPorUso (em Watts), Ativo (bool).
o Método Usar(): adiciona o consumo ao total da casa.

2. Classe SistemaEnergia
o Armazena a lista de dispositivos.
o Controla o consumo total.
o Contém o evento ConsumoElevado.
o Define o limite de consumo (ex: 1000W).

3. Delegate
o Crie um delegate void AlertaConsumoHandler(string nomeDispositivo, 
double consumoAtual).

4. Evento ConsumoElevado
o Disparado quando o consumo total ultrapassa o limite.
o Deve chamar os métodos ouvintes.

5. Assinantes
o Um método exibe uma mensagem de alerta no console.
o Outro simula o desligamento automático de dispositivos de 
alto consumo.

 */

var sistema = new SistemaEnergia();

// Configurar gerenciador de alertas (assina os eventos)
var gerenciador = new GerenciadorAlertas(sistema);

// Criar dispositivos elétricos
var arCondicionado = new DispositivoEletrico
{
    Nome = "Ar Condicionado",
    ConsumoPorUso = 800,
    Ativo = true,
    SistemaEnergia = sistema
};

var geladeira = new DispositivoEletrico
{
    Nome = "Geladeira",
    ConsumoPorUso = 150,
    Ativo = true,
    SistemaEnergia = sistema
};

var computador = new DispositivoEletrico
{
    Nome = "Computador",
    ConsumoPorUso = 300,
    Ativo = true,
    SistemaEnergia = sistema
};

var chuveiro = new DispositivoEletrico
{
    Nome = "Chuveiro",
    ConsumoPorUso = 600,
    Ativo = true,
    SistemaEnergia = sistema
};

// Adicionar dispositivos ao sistema
sistema.DispositivoEletricos.Add(arCondicionado);
sistema.DispositivoEletricos.Add(geladeira);
sistema.DispositivoEletricos.Add(computador);
sistema.DispositivoEletricos.Add(chuveiro);

// Simular uso dos dispositivos
Console.WriteLine("=== SIMULAÇÃO DE CONSUMO DE ENERGIA ===");
Console.WriteLine();

geladeira.Usar();        // 150W
computador.Usar();       // 300W (total: 450W)
arCondicionado.Usar();   // 800W (total: 1250W) -> DISPARA EVENTO!
chuveiro.Usar();         // 5500W (total: 6750W) -> DISPARA EVENTO NOVAMENTE!



public class DispositivoEletrico
{
    public string? Nome { get; set; }
    public int ConsumoPorUso { get; set; }
    public bool Ativo { get; set; }
    public SistemaEnergia SistemaEnergia { get; set; }

    public void Usar()
    {
        if (Ativo)
        {
            SistemaEnergia?.AdicionarConsumo(ConsumoPorUso, this);
            Console.WriteLine($"{Nome} consumiu {ConsumoPorUso}W");
        }
        else
        {
            Console.WriteLine($"{Nome} está desligado e não pode ser usado");
        }
    }
}

public delegate void AlertaConsumoHandler(string nomeDispositivo, double consumoAtual);
public class SistemaEnergia
{
    public int ConsumoLimite = 1000;
    private double consumoTotal = 0;
    public event AlertaConsumoHandler ConsumoElevado;
    public List<DispositivoEletrico> DispositivoEletricos { get; set; } = new List<DispositivoEletrico>();

    public double ConsumoTotal
    {
        get => consumoTotal;
        private set
        {
            consumoTotal = value;

            if (consumoTotal > ConsumoLimite)
            {
                var dispositivoMaiorConsumo = ObterDispositivoMaiorConsumo();
                ConsumoElevado?.Invoke(dispositivoMaiorConsumo?.Nome ?? "Desconhecido", consumoTotal);
            }
        }
    }

    public void AdicionarConsumo(int consumo, DispositivoEletrico dispositivo)
    {
        ConsumoTotal += consumo;
    }

    private DispositivoEletrico ObterDispositivoMaiorConsumo()
    {
        return DispositivoEletricos.OrderByDescending(d => d.ConsumoPorUso).FirstOrDefault();
    }

    public void DesligarDispositivosAltoConsumo()
    {
        var dispositivosAltosConsumo = DispositivoEletricos.Where(d => d.Ativo && d.ConsumoPorUso > 200).OrderByDescending(d => d.ConsumoPorUso).ToList();

        foreach (var dispositivo in dispositivosAltosConsumo)
        {
            dispositivo.Ativo = false;
            Console.WriteLine($"Dispositivo {dispositivo.Nome} foi desligado automaticamente!");

            ConsumoTotal -= dispositivo.ConsumoPorUso;

            if (ConsumoTotal <= ConsumoLimite) break;
        }
    }
}


public class GerenciadorAlertas
{
    private SistemaEnergia SistemaEnergia;
    public GerenciadorAlertas(SistemaEnergia sistemaEnergia)
    {
        SistemaEnergia = sistemaEnergia;
        SistemaEnergia.ConsumoElevado += ExibirAlertaConsole;
        SistemaEnergia.ConsumoElevado += DesligarDispositivosAutomaticamente;
    }

    private void ExibirAlertaConsole(string nomeDispositivo, double consumoAtual)
    {
        Console.WriteLine($"ALERTA DE CONSUMO");
        Console.WriteLine($"Consumo total: {consumoAtual}W");
        Console.WriteLine($"Dispositivo com maior consumo: {nomeDispositivo}");
        Console.WriteLine($"Limite: {SistemaEnergia.ConsumoLimite}W");
        Console.WriteLine();
    }

    private void DesligarDispositivosAutomaticamente(string nomeDispositivo, double consumoAtual)
    {
        Console.WriteLine("Iniciando desligamento automático de dispositivos...");
        SistemaEnergia.DesligarDispositivosAltoConsumo();
        Console.WriteLine($"Consumo após desligamento: {SistemaEnergia.ConsumoTotal}W");
        Console.WriteLine();
    }
}