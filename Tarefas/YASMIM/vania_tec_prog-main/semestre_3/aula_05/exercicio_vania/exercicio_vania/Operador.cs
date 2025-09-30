using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_vania
{
    internal class Operador
    {
        public string Nome { get; set; }
        public Maquina Maquina { get; set; }

        public Operador(string nome, Maquina maquina)
        {
            Nome = nome;
            Maquina = maquina;
        }

        public async Task OperarMaquinaAsync(Fabrica fabrica, string modelo)
        {
            Console.WriteLine($"Operador {Nome} está tentando operar a máquina modelo {modelo}");
            await Task.Delay(2000);

            var maquina = fabrica.BuscarMaquinaPorModelo(modelo);
            if (maquina != null)
            {
                Console.WriteLine($"{Nome} agora está operando a máquina modelo {modelo}!");
                return;
            }

            Console.WriteLine($"Máquina modelo {modelo} não encontrada na fábrica {fabrica.Nome}");
        }
    }
}
