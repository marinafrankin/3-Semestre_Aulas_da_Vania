using Microsoft.Win32;
using System;

public class Participante
{ 
    public string Aluno { get; set; }
    public string Evento { get; set; }
    public DateTime Data { get; set; }
    public int CargaHoraria { get; set; }

    public Participante(string aluno, string evento, DateTime data, int cargaHoraria)
    {
        Aluno = aluno;
        Evento = evento;
        Data = data;
        CargaHoraria = cargaHoraria;
    }
}


public class RegistroAcademico
{
    private List<Participante> _participacao { get; set; }

    public delegate void ParticipacaoHandler(Participante p);

    public event ParticipacaoHandler ParticipanteRegistrado;


    public RegistroAcademico()
    {
        _participacao = new List<Participante>();
    }

    public void Registrar(Participante p)
    {
        _participacao.Add(p);
        ParticipanteRegistrado?.Invoke(p);

        Console.WriteLine($"[Registro]{p.Aluno} registrado com sucesso no evento '{p.Evento}'. ");

    }

    public void ApresentarTodos()
    {
        if (_participacao.Count == 0)
        {
            Console.WriteLine("Nenhum participante ainda");
            return;
        }
        foreach(var p in _participacao)
        {
            Console.WriteLine($"{p.Data.ToShortDateString()},");
            Console.WriteLine($"Aluno: {p.Aluno},");
            Console.WriteLine($"Evento: {p.Evento},");
            Console.WriteLine($"Carga Horária: {p.CargaHoraria}h.");
        }
    }
}

public static class Ouvintes
{
    public static void Participacao(Participante p)
    {
        Console.WriteLine($"Varificando: {p.Aluno} participou do evento {p.Evento}. ");
    }
    public static void CargaHoraria (Participante p)
    {
        if(p.CargaHoraria > 10)
        {
            Console.WriteLine($"Participação com carga horária {p.CargaHoraria}h. ");
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------------");

        var registro = new RegistroAcademico();

        Console.WriteLine("Ouvintes no evento, Participação registrada ! ");
        registro.ParticipanteRegistrado += Ouvintes.Participacao;
        registro.ParticipanteRegistrado += Ouvintes.CargaHoraria;

        var part1 = new Participante("Ana", "PetShop Scooby-Doo", DateTime.Now, 8);
        var part2 = new Participante("Velma", "Detetive Scooby-Doo", DateTime.Now.AddDays(-5), 10);
        var part3 = new Participante("Fredy", "Mecânico Scooby-Doo", DateTime.Now.AddMonths(-1), 3);

        Console.WriteLine("Primeiro registro: ");
        registro.Registrar(part1);

        Console.WriteLine("Segundo registro: ");
        registro.Registrar(part2);

        registro.Registrar(part3);

        registro.ApresentarTodos();
        Console.WriteLine(" Final de Eventos ! ");
    }
}