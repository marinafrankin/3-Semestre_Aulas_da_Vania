using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_vania
{
    internal class Fabrica
    {
        public string Nome { get; set; }
        public ICollection<Maquina> Maquinas { get; }

        public void AdicionarMaquina(Maquina maquina) 
        {
            Maquinas.Add(maquina);
        }

        public Fabrica(string nomeFabrica, string modelo, string hora, string nome, DateTime data) 
        { 
            Nome = nomeFabrica;
            Maquinas = new List<Maquina>();

            Maquina maquina = new Maquina(modelo, hora, nome, data);
            AdicionarMaquina(maquina);
        }

        public void ListarMaquinas() 
        { 
            foreach (var maquina in Maquinas)
            {
                Console.WriteLine("---- Dados da Máquina ----");
                Console.WriteLine($"Modelo: {maquina.Modelo}");
                Console.WriteLine($"Hora da Operação: {maquina.HoraOperacao}");
                Console.WriteLine($"Numero da Série: {maquina.NumeroSerie}\n");

                Console.WriteLine("---- Dados do Equipamento ----");
                Console.WriteLine($"Hora da Operação: {maquina.Nome}");
                Console.WriteLine($"Data da Fabricação: {maquina.DataFabricacao}\n");
            }
        }

        public Maquina BuscarMaquinaPorModelo(string modelo) 
        {
            return Maquinas.FirstOrDefault((maq) => maq.Modelo == modelo);
        }
    }
}
