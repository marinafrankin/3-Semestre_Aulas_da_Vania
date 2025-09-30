// 3. Crie um programa que gerencie uma coleção de nomes de alunos utilizando ICollection<string>. O programa deve permitir:
ICollection<string> alunos = new List<string>();

// · Adicionar alunos à coleção, solicite os nomes ao usuário
Console.Write("Digite o nome do primeiro aluno: ");
string aluno1 = Console.ReadLine();

Console.Write("Digite o nome do segundo aluno: ");
string aluno2 = Console.ReadLine();

Console.Write("Digite o nome do terceiro aluno: ");
string aluno3 = Console.ReadLine();

alunos.Add(aluno1);
alunos.Add(aluno2);
alunos.Add(aluno3);

// · Verificar se um aluno específico está na coleção
Console.Write("Digite o nome do aluno que deseja encontrar: ");
string alunoProcurado = Console.ReadLine();

if (alunos.Contains(alunoProcurado))
{
    Console.WriteLine("O aluno existe!");
}
else
{
    Console.WriteLine("O aluno não existe!");
}

// · Remover um aluno, solicite o nome ao usuário
Console.Write("Digite o nome do aluno que deseja remover: ");
string alunoRemov = Console.ReadLine();

if (alunos.Remove(alunoRemov))
{
    Console.WriteLine("Aluno removido!");
}
else
{
    Console.WriteLine("Aluno não encontrado!");
}

// · Exibir todos os alunos
Console.WriteLine("----- Lista de Alunos ----");
foreach (var aluno in alunos)
{
    Console.WriteLine(aluno);
}