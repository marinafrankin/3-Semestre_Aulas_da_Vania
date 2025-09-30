namespace atividade_06
{
    internal class Program
    {
    /*
     6. Crie uma classe Livro com Título e Autor, e armazene objetos dessa
       classe em uma ICollection<Livro>.
       • Adicione alguns livros
       • Exiba a lista de livros
     */
        static void Main(string[] args)
        {
            ICollection<Livro> livros = new List<Livro>();
            livros.Add(new Livro("Harry Potter e a Pedra Fisiolofal", "JK Rollie"));
            livros.Add(new Livro("boruto", "massashi kimishimoto"));
            livros.Add(new Livro("One Piece", "Echiro Oda"));

            foreach (var livro in livros)
            {
                Console.WriteLine(livro);
            }
        }
    }
}
