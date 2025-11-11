

/*
    3. Controle de Usuário


Você irá desenvolver um sistema simples para gerenciar usuários 
de um aplicativo. O sistema deve permitir o cadastro de usuários 
e realizar algumas ações automáticas ao longo do processo.

Cada vez que um novo usuário for cadastrado:

· Um evento chamado UsuarioCadastrado deve ser disparado.
· Esse evento deve ser baseado em um delegate personalizado, 
que define a assinatura dos métodos de notificação 
(ex: enviar email, registrar log etc.).
· Os ouvintes do evento deverão executar ações diferentes, como:

o Exibir uma mensagem no console.

o Gravar uma entrada em um arquivo 
de log .txt com data e hora do cadastro.
· O sistema deve manter uma lista de usuários na memória.
· Deve permitir que o usuário consulte os dados utilizando LINQ:

o Filtrar usuários maiores de idade.

o Agrupar usuários por domínio do email.

o Listar os 3 mais recentes cadastrados.
· A lista de usuários deve ser serializada em JSON e salva em um 
arquivo.
· O sistema também deve permitir desserializar esse arquivo 
JSON para carregar os dados ao iniciar.

Requisitos:

1. Classe Usuario
o Propriedades: Nome, Email, Idade, DataCadastro.

2. Classe GerenciadorUsuarios
o Contém lista de usuários.
o Método CadastrarUsuario(Usuario usuario):
§ Adiciona o usuário à lista.
§ Dispara o evento UsuarioCadastrado.

3. Delegate e Evento
o Crie um delegate void NotificacaoHandler(Usuario usuario).
o O evento UsuarioCadastrado será do tipo NotificacaoHandler.

4. Ouvintes(assinante) do Evento
o Um método escreve no console: "Novo usuário: {Nome}, 
cadastrado em {DataCadastro}".
o Outro grava no arquivo log.txt a mesma mensagem. 
*/


using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;



GerenciadorUsuarios gerenciador = new GerenciadorUsuarios();

// Assinantes
gerenciador.UsuarioCadastrado += Notificacoes.NovoUsuario;
gerenciador.UsuarioCadastrado += Notificacoes.SalvarLog;

bool continuar = true;

while (continuar)
{
    
    Console.Write("Escolha uma opção: ");

    Console.WriteLine("--- Menu de Usuários ---");
    Console.WriteLine("1. Cadastrar Usuário");
    Console.WriteLine("2. Listar todos os usuários");
    Console.WriteLine("3. Filtrar usuários maiores de idade");
    Console.WriteLine("4. Agrupar usuários por domínio de e-mail");
    Console.WriteLine("5. Listar 3 usuários mais recentes");
    Console.WriteLine("6. Salvar usuários em JSON");
    Console.WriteLine("7. Sair");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            var novoUsuario = new Usuario(nome, email, idade);
            gerenciador.CadastrarUsuarios(novoUsuario);
            break;

        case "2":
            gerenciador.ExibirListaUsuarios();
            break;

        case "3":
            var maiores = gerenciador.Usuarios.Where(u => u.Idade >= 18).ToList();

            Console.Clear();
            Console.WriteLine("--- Usuários maior de idade ---");
            gerenciador.ExibirUsuariosFiltrados(maiores);
            break;

        case "4":
            var gruposPorDominios = gerenciador.Usuarios.Select(u => u.Email.Split('@')[1]).Distinct();

            Console.Clear();
            Console.WriteLine("--- Usuários por domínios de e-mail ---");

            if (gerenciador.Usuarios.Count == 0)
            {
                Console.WriteLine("\nNenhum usuário cadastrado!");
            }

            foreach (var dominio in gruposPorDominios)
            {
                Console.WriteLine($"\n[Domínio: {dominio}]");
                foreach (var user in gerenciador.Usuarios.Where(u => u.Email.EndsWith("@" + dominio)))
                {
                    Console.WriteLine($"- {user.Nome} ({user.Email})");
                }
            }
            break;

        case "5":
            var recentes = gerenciador.Usuarios.OrderByDescending(u => u.DataCadastra).Take(3).ToList();

            Console.Clear();
            Console.WriteLine("--- 3 usuários mais recentes ---");
            gerenciador.ExibirUsuariosFiltrados(recentes);
            break;

        case "6":
            Console.Clear();
            gerenciador.SerializarJson();
            Console.WriteLine("Usuários salvos em usuarios.json");
            break;

        case "7":
            Console.WriteLine("Saindo...");
            continuar = false;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            break;
    }
}




public delegate void NotificacaoHandler(Usuario usuario);

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }
    public DateTime DataCadastra { get; set; } = DateTime.Now;

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}


public class GerenciadorUsuarios
{
    public event NotificacaoHandler UsuarioCadastrado;
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();


    public GerenciadorUsuarios()
    {
        DesserializarJson(); //carregar todos os usuarios de json ao iniciar
    }


    public void CadastrarUsuarios(Usuario usuario)
    {
        if (usuario == null) return;

        Usuarios.Add(usuario);

        UsuarioCadastrado.Invoke(usuario);
    }


    public void SerializarJson() // ele transforma uma lista em json
    {
        if (Usuarios.Count == 0) return; //ele vê se a lista de usuarios tá vazia ou não

        Console.WriteLine("SUCESSO");

        string caminho = "usuarios.json";

        string jsonString = JsonSerializer.Serialize(Usuarios, new JsonSerializerOptions
        {
            WriteIndented = true, // ele formata o arquivo automaticamente
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        });
        File.WriteAllText(caminho, jsonString);
    }

    public void DesserializarJson() //ele pega o arquivo json e transforma em uma lista 
    {
        string caminho = "usuarios.json";

        if (File.Exists(caminho))
        {
            string conteudoJson = File.ReadAllText(caminho);

            var users = JsonSerializer.Deserialize<List<Usuario>>(conteudoJson);

            if (users != null)
            {
                Usuarios.AddRange(users); 
                // adiciona uma lista de novos usuários no final da propriedade Usuarios
            }
        }
    }

    public void ExibirListaUsuarios()
    {
        Console.WriteLine("LISTA DE USUÁRIOS: ");
        if (Usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuario cadastrado");
            return;
        }
        foreach (var user in Usuarios)
        {
            Console.WriteLine($"Nome: {user.Nome} | ");
            Console.WriteLine($"Email: {user.Email} | ");
            Console.WriteLine($"Idade: {user.Idade} | ");
            Console.WriteLine($"Data de cadastro: {user.DataCadastra}.");
        }
    }

    public void ExibirUsuariosFiltrados(List<Usuario> usuarios)
    {
        if (Usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuario cadastrado");
            return;
        }
        foreach (var user in Usuarios)
        {
            Console.WriteLine($"Nome: {user.Nome} | ");
            Console.WriteLine($"Email: {user.Email} | ");
            Console.WriteLine($"Idade: {user.Idade} anos | ");
            Console.WriteLine($"Data de cadastro: {user.DataCadastra}.");
        }
    }
}


public static class Notificacoes
{
    public static void NovoUsuario(Usuario usuario)
    {
        Console.WriteLine("SUCESSO");
        Console.WriteLine($" Novo usuário: {usuario.Nome}, cadastrado em {usuario.DataCadastra}");
    }

    public static void SalvarLog(Usuario usuario)
    {
        var caminho = "log.txt";
        var mensagem = $"Novo usuário: {usuario.Nome}, cadastrado em {usuario.DataCadastra}";

        if (!File.Exists(caminho))
        {
            File.WriteAllText(caminho, mensagem);
            return;
        }

        File.AppendAllText(caminho, mensagem);
    }
}

