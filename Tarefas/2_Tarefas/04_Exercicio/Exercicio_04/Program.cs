/* 
    4. Crie uma ICollection<double> para armazenar preços de produtos. 
         Depois, copie os valores para um array e exiba os preços.
*/

using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Produtos()
    {
        ICollection<double> precos = new List<double>();

        precos.Add(20.50);
        precos.Add(50.69);
        precos.Add(45.00);
        precos.Add(90.00);

        Console.WriteLine("Preços de produtos: ");
        foreach (var preco in precos)
        {
            Console.WriteLine($"R$ {preco}");
        }

        Console.WriteLine(new string(' ', 30));

        double[] arrayPrecos = new double[precos.Count];
        precos.CopyTo(arrayPrecos, 0);


        Console.WriteLine("Preços copiados para o array: ");
        foreach (var preco in arrayPrecos)
        {
            Console.WriteLine($"R$ {preco}");
        }
    }
}