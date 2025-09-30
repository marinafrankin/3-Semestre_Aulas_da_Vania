namespace atividade_07
{
    internal class Program
    {
     /*
     7. Faça:
       • Crie uma classe Usuario com as propriedades Id e Nome.
       • Crie uma classe RepositorioUsuarios que contenha uma lista
       interna de usuários.
       • Essa classe deve ter um método ConsultarUsuarioPorIdAsync(int
       id) que simule buscar o usuário no “banco remoto”, usando
       Task.Delay para representar o tempo de rede.
       • Faça consultas a alguns usuários (existentes e inexistentes).
     */
        static async Task Main(string[] args)
        {
            var repositorio = new RepositorioUsuario();

            Console.WriteLine("Consultando usuários existentes:");

            await repositorio.ConsultarUsuarioPorIdAsync(1);

            await repositorio.ConsultarUsuarioPorIdAsync(2);

            await repositorio.ConsultarUsuarioPorIdAsync(20);

            await repositorio.ConsultarUsuarioPorIdAsync(30);
        }
    }
}
