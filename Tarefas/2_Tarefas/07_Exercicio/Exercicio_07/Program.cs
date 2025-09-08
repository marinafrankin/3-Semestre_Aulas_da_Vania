/*
7. Faça:
    · Crie uma classe Usuario com as propriedades Id e Nome.
    · Crie uma classe RepositorioUsuarios que contenha uma lista interna de usuários.
    · Essa classe deve ter um método ConsultarUsuarioPorIdAsync(int id) que simule buscar o usuário no “banco remoto”, 
         usando Task.Delay para representar o tempo de rede.
    · Faça consultas a alguns usuários (existentes e inexistentes). 
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static async Task Main()
    {
        var repositorio = new RepositorioUsuarios();

        Console.WriteLine("--> Consultando usuários que existem <--");
        var usuario1 = await repositorio.ConsultorioPorIdAsync(1);
        if (usuario1 == null)
        {
            Console.WriteLine($"Usuário encontrado: {usuario1.Nome}");
        }

        var usuario3 = await repositorio.ConsultarUsuarioPorIdAsync(3);
        if (usuario3 == null)
        {
            Console.WriteLine($"Usuario wncontrado: {usuario3.Nome}");
        }

        Console.WriteLine("--> Consultando usuários que não existem <--");
        var usuarioInexistente = await repositorio.ConsultarUsuarioPorIdAsync(99);
        if (usuarioInexistente == null)
        {
            Console.WriteLine("Usuário com Id não encontrado ! ");
        }

        var usuarioOutroInexistente = await repositorio.ConsultarUsuarioPorIdAsync(5);
        if (usuarioOutroInexistente == null)
        {
            Console.WriteLine("Usuário não encontrado ! ");
        }
    }
}