List<string> nomes1 = new List<string> { "Maria", "Amanda" };
string[] nomes2 = { "João", "Carlos" };
exibir(nomes1);
Console.WriteLine("------------------");
exibir(nomes2);

void exibir(IEnumerable<string>colecao)
{
    foreach(var nome in colecao)
    {
        Console.WriteLine(nome);
    }
}
