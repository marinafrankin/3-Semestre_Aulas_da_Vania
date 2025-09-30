using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_vania
{
    internal class Maquina : Equipamento
    {
        public string Modelo { get; set; }
        public string HoraOperacao { get; set; }

        // Apenas LEITURA (readOnly) - criar atributo privado para mexer no público
        private readonly Guid numeroserie;
        public Guid NumeroSerie { get; }

        // Apenas SET (writeOnly)
        private string? observacao;
        public string Observacao
        {
            set { observacao = value; }
        }

        public Maquina(string modelo, string hora, string nome, DateTime data): base(nome, data) 
        {
            Modelo = modelo;
            HoraOperacao = hora;
            NumeroSerie = numeroserie;
            Observacao = observacao;
        }
    }
}
