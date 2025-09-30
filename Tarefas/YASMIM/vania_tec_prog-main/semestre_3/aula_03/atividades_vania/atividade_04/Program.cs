// 4. Crie uma ICollection<double> para armazenar preços de produtos.
ICollection<double> precosProdutos = new List<double>();
int contador = 0;

precosProdutos.Add(5.74);
precosProdutos.Add(6.41);
precosProdutos.Add(1.57);

// Depois, copie os valores para um array e exiba os preços.
List<double> precos = new List<double>();

foreach (var preco in precosProdutos)
{
    precos.Add(preco);
}

foreach (var preco in precos)
{
    Console.WriteLine(preco);
}


