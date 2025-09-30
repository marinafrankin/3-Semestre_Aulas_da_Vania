using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_07
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Usuario(){}

        public override string ToString()
        {
            return "{ Nome: " + Nome + ", Id: " + Id + " }";
        }
    }
}
