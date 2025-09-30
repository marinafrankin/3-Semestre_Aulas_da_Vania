using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_06
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }

        public override string ToString()
        {
            return $"Livro: {Titulo}, Autor: {Autor}";
        }
    }
}
