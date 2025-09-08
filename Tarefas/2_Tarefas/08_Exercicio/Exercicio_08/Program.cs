/*
    8. Crie classe download e um método BaixarArquivoAsync que 
simule o download de um arquivo com Task.Delay(3000). 
O método deve exibir mensagens antes e depois da espera. 
*/

using System;
using System.Threading.Tasks;

public class Download
{
    public async Task BaixarArquivosAsync(string nomeArquivo)
    {
        Console.WriteLine($"Iniciaando o download do arquivo '{nomeArquivo}'...");
        await Task.Delay(3000);
        Console.WriteLine($"O arquivo '{nomeArquivo}' foi baixado com sucesso");
    }
}

class Program
{
    static async Task Main()
    {
        var downloadManager = new Download();

        await downloadManager.BaixarArquivosAsync("RelatorioMensal.pdf");
        Console.WriteLine("Download finalizado ! ");
    }
}