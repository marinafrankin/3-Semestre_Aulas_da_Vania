﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_vania
{
    internal class Equipamento
    {
        public string Nome { get; set; }
        public DateTime DataFabricacao { get; set; }

        public Equipamento(string nome, DateTime data)
        {
            Nome = nome;
            DataFabricacao = data;
        }
    }
}
