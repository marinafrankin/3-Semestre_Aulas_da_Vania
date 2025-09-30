using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_08
{
    internal class dowload
    {
        public async Task BaixarArquivoAsync()
        {
            Console.WriteLine("Iniciando Dowload");
            await Task.Delay(3000);
            Console.WriteLine("Fim do Dowload");
        }
    }
}
