// Exercicio 03

using System;
using System.Runtime.InteropServices;

// Array bidimensional [grupos, alunos]
float[,] notas = new float[2, 5]; // No caso são 2 grupos de alunos, cada um com 5 integrantes cada;

Console.WriteLine("Digite as notas dos alunos de sua turma: ");

for (int grupo = 0; grupo < 2; grupo++)
{
    Console.WriteLine("Grupo: ");
    for (int aluno = 0; aluno < 5; aluno++)
    {
        Console.Write($"Informe a nota do aluno: ");
        notas[grupo, aluno] = float.Parse( Console.ReadLine());
    }
}

for (int grupo = 0; grupo < 2; grupo++)
{
    float soma = 0;
    for(int aluno = 0;aluno < 5; aluno++)
    {
        soma += notas[grupo, aluno];
    }

    float media = soma / 5;
    Console.WriteLine("Média dos grupos: ");
}

Console.WriteLine("Notas e médias inceridas com sucesso");