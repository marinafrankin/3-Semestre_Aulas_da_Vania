/* 
 3. Crie um programa que gerencie uma coleção de nomes de alunos utilizando ICollection<string>. O programa deve permitir:
        · Adicionar alunos à coleção, solicite os nomes ao usuário
        · Verificar se um aluno específico está na coleção
        · Remover um aluno, solicite o nome ao usuário
        · Exibir todos os alunos
*/

using System;

static void Alunos(string[] args)
{
    ICollection<string> alunos = new List<string>();

    while(true)
    {
        Console.WriteLine("--> Bem-Vindo Professor ! <--");
        Console.WriteLine("1 - Adicionar aluno");
        Console.WriteLine("2 - Verificar se aluno existe");
        Console.WriteLine("3 - Remover aluno");
        Console.WriteLine("4 - Exibir todos os alunos");
        Console.Write("Escolha uma opção: ");

        string entrada = Console.ReadLine();
        int opcao;

        if(!int.TryParse(entrada, out opcao))
        {
            Console.WriteLine("Digite apenas números ! ");
            continue;
        }

        switch(opcao)
        {
            case 0:
                Console.WriteLine("Finalizando a lista de chamada !");
                return;

                default:
                    Console.WriteLine("Opção inválida, tente denovo ! ");
                break;


            case 1:
                Console.Write("Digite o nome do aluno para adicionar a lista de chamada: ");
                string nomeAdd = Console.ReadLine();
                alunos.Add(nomeAdd);
                Console.WriteLine($"Aluno '{nomeAdd}' adicionado com sucesso ! ");
                break;


            case 2:
                Console.Write("Digite o nome do aluno para verificar se está na chamada: ");
                string nomeVerifica = Console.ReadLine();
                if (alunos.Contains(nomeVerifica))
                    Console.WriteLine($"O aluno '{nomeVerifica}' está na chamada ! ");
                else
                    Console.WriteLine($"O aluno '{nomeVerifica}' não encontrado ! ");
                break;


            case 3:
                Console.Write("Digite o nome do aluno para removê-lo da chamada: ");
                string nomeRemove = Console.ReadLine();
                if (alunos.Remove(nomeRemove))
                    Console.WriteLine($"Aluno '{nomeRemove}' removido da lista com sucesso ! ");
                else
                    Console.WriteLine($"O aluno '{nomeRemove}' não encontrado ! ");
                break;

            case 4:
                Console.WriteLine("Lista de alunos cadastrados na lista de chamada:");
                if (alunos.Count == 0)
                    Console.WriteLine("Nenhum aluno cadastrado na lista de chamada ! ");
                else
                {
                foreach (string aluno in alunos)
                   Console.WriteLine($"- {aluno}");
                }
                break;
        }
    }
}