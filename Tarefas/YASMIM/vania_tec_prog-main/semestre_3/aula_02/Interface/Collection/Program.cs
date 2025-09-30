// IEnumerable<T> e ICollection<T> são interfaces genéricas com mecanismos para percorrer coleções usando ForEach
// Diferenças: IEnumerable não permite alterar a coleção (adicionar, remover e contar itens), ICollection sim 
// Privilégio: Desacoplamento

ICollection<string> nomes = new List<string> { "Bernardo", "Rafael"};

nomes.Add("Clara");
exibir(nomes);

nomes.Remove("Rafael");
Console.WriteLine("-------------------");
exibir(nomes);
Console.WriteLine(nomes.Count);
void exibir(ICollection<string> colecao)
{
    foreach (var nome in colecao)
    {
        Console.WriteLine(nome);
    }
}