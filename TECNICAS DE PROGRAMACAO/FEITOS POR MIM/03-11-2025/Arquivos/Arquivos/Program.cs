

var caminho = @"C:\Users\Marina\Desktop\3 Semestre Aulas_Vania\TECNICAS DE PROGRAMACAO\FEITOS POR MIM\03-11-2025\arquivo1.txt";


if (File.Exists(caminho))
{
    File.WriteAllText(caminho, "Autor desconhecido. ");
}
//File.WriteAllText(caminho, "Autor Desconhecido");
//string conteudo = File.ReadAllText(caminho);

//Console.WriteLine(conteudo);

var novoTexto = "Quem canta seus males espanta" + Environment.NewLine + "Água mole em pedra dura tanto bate até que fura";
File.AppendAllText(caminho, novoTexto);

string conteudo = File.ReadAllText(caminho);

Console.WriteLine(conteudo);