// IEnumerable<T> e ICollection<T> são interfaces genéricas com mecanismos para percorrer coleções usando ForEach
// Diferenças: IEnumerable não permite alterar a coleção (adicionar, remover e contar itens), ICollection sim 
// Privilégio: Desacoplamento

List<string> listaH = new List<string> { "Kaique", "Gabriel" };
string[] listaM = { "Marina", "Yasmin" };
Console.WriteLine("Lista de Homens\n");
exibir(listaH);
Console.WriteLine("--------------");
Console.WriteLine("Lista de Mulheres\n");
exibir(listaM);

void exibir(IEnumerable<string> colecao)
{
    foreach (var nome in colecao)
    { 
        Console.WriteLine(nome);
    }
}

