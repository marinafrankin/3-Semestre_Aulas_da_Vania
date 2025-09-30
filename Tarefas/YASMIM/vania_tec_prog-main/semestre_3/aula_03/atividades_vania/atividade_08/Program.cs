namespace atividade_08
{
    internal class Program
    {
     /*
        Crie classe download e um método BaixarArquivoAsync que simule o download de um arquivo com Task.Delay(3000). O método deve exibir
        mensagens antes e depois da espera.
     */
        static async Task Main(string[] args)
        {
            dowload dowload = new dowload();
            await dowload.BaixarArquivoAsync();
        }
    }
}
