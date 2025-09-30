using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_09
{
    internal class ArquivoService
    {
        public ArquivoService(){}

        public async Task BuscarDadosAsync()
        {
            Console.WriteLine("BuscarDadosAsync Terminou");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("BuscarDadosAsync Terminou");
        }

        public async Task ProcessarDadosAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("ProcessarDadosAsync Terminou");
        }

        public async Task SalvarDadosAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("SalvarDadosAsync Terminou");
        }
    }
}
