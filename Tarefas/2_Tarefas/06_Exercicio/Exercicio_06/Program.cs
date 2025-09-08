/*
     6. Crie uma classe Livro com Título e Autor, e 
armazene objetos dessa classe em uma ICollection<Livro>.
· Adicione alguns livros
· Exiba a lista de livros
*/

using System;
using System.Collections.Generic;


public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }

    public Livro (string titulo, string autor)
    {
        this.Titulo = titulo;
        this.Autor = autor;
    }


    public override string ToString()
    {
        return $"'{this.Titulo}' por {this.Autor}";
    }
}


public class Program
{
    public static void Main()
    {
        ICollection<Livro> biblioteca = new List<Livro> ();

        biblioteca.Add(new Livro("Olhos Prateados", "Scott Calton"));
        biblioteca.Add(new Livro("O Senhor dos Aneis", "J.R.R Tolkien"));
        biblioteca.Add(new Livro("Dom Quixote", "Miguel de Cervantes"));
        biblioteca.Add(new Livro("Cem Anos de Solidão", "Gabriel Garcia Marquez"));

        Console.WriteLine("--> Livros da Biblioteca <--");
        if(biblioteca.Count == 0)
        {
            Console.WriteLine("Não há livros na biblioteca");
        }
        else
        {
            foreach(Livro livro in biblioteca)
            {
                Console.WriteLine(livro);
            }
        }
        Console.WriteLine("-------------------------");
    }
}