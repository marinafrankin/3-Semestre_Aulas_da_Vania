using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade_07
{
    internal class RepositorioUsuario
    {
        public List<Usuario> ListaDeUsuarios { get; set; }

        public RepositorioUsuario()
        {
            ListaDeUsuarios = new List<Usuario>();

            for (int i = 1; i <= 10; i++)
            {
                ListaDeUsuarios.Add(new Usuario
                {
                    Id = i,
                    Nome = $"Usuário {i}",

                });
            }
        }

        public async Task ConsultarUsuarioPorIdAsync(int id)
        {
            Console.WriteLine("iniciado consulta");
            await Task.Delay(TimeSpan.FromSeconds(3));

            var user = ListaDeUsuarios.Find(usuario => usuario.Id == id);
            if (user == null)
            {
                Console.WriteLine("não encontrado");
                return;
            }
            Console.WriteLine($"usuario encontrado :" + user);
        }
    }
}
