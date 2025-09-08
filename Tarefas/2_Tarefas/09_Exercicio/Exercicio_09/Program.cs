/*
    9. Na classe ProcessarDados, crie quatro métodos assíncronos:
    · BuscarDadosAsync() → demora 2s
    · ProcessarDadosAsync() → demora 4s
    · SalvarDadosAsync() → demora 1s
    · principal rode as três tarefas em 
        paralelo e aguarde todas terminarem com Task.WhenAll. 
*/

public class ProcessandoDados
{
    public async Task BuscarDadosAsync()
    {
        Console.WriteLine("Buscando dados: ");
        await Task.Delay(2000);
        Console.WriteLine("Busca de dados concluída ! ");
    }


    public async Task ProcessarDadosAsync()
    {
        Console.WriteLine("Processando dados: ");
        await Task.Delay(4000);
        Console.WriteLine("Dados processados com sucessor ! ");
    }


    public async Task SalvarDadosAsync()
    { 
        Console.WriteLine("Salvando dados...");
        await Task.Delay(1000);
        Console.WriteLine("Dados salvos com sucesso !");
    }
}


public class Program
{
    public static async Task Main()
    {
        var processador = new ProcessandoDados();
        Console.WriteLine("Iniciando o processamento de tarefas...");

        Task tarefaBusca = processador.BuscarDadosAsync();
        Task tarefaProcessamento = processador.ProcessarDadosAsync();
        Task tarefaSalvamento = processador.SalvarDadosAsync();

        await Task.WhenAll(tarefaBusca, tarefaProcessamento, tarefaSalvamento);
        Console.WriteLine("Todas as tarefas foram concluídas ! ");
    }
}