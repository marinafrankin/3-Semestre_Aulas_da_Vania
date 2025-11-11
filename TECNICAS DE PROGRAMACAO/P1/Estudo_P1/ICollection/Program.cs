

/*
 
    ICollection

*/

List<string> nomes = new List<string> { "Maria", "Amanda" };

nomes.Add("Clara");
exibir(nomes);

nomes.Remove("Maria");
Console.WriteLine("----------------");
exibir(nomes);

Console.WriteLine(nomes.Count);

void exibir(IEnumerable<string> colecao)
{
    foreach (var nome in colecao)
    {
        Console.WriteLine(nome);
    }
}