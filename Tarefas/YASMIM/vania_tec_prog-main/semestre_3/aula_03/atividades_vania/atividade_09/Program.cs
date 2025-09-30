namespace atividade_09
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var arquivoService = new ArquivoService();
            await ProcessarEmParalelo(arquivoService);
        }

        public static async Task ProcessarEmParalelo(ArquivoService arquivoService)
        {
            Console.WriteLine("Iniciando processamento em paralelo...");


            var buscarTask = arquivoService.BuscarDadosAsync();
            var processarTask = arquivoService.ProcessarDadosAsync();
            var salvarTask = arquivoService.SalvarDadosAsync();

            await Task.WhenAll(buscarTask, processarTask, salvarTask);

            Console.WriteLine("Todas as tarefas foram concluídas!");
        }
    }
}
