

/*
 
 3.	Crie um programa que solicite ao usuário que informe a sua idade. 
Se a idade for menor que 0 ou maior que 150, dispare uma exceção 
personalizada chamada IdadeInvalidaException. Caso contrário, 
imprima uma mensagem dizendo que a idade foi registrada com sucesso.

*/

try 
{
    Console.Write("Digite o nome de usuário: ");
    string nomeUsu = Console.ReadLine();

    Console.Write("Digite a idade de usuário: ");
    int idadeUsu = Convert.ToInt32(Console.ReadLine());

    Usuarios usuarios = new Usuarios(nomeUsu, idadeUsu);

    Console.Write("Usuário registrado com sucesso !");
}
catch (IdadeInvalidaException e)
{
    Console.WriteLine("Erro de idade:" + e.Message);
}
catch (NomeInvalidoException e)
{
    Console.WriteLine("Erro de nome:" + e.Message);
}
catch (FormatException)
{
    Console.WriteLine("Verifique o formato");
}
finally
{
    Console.WriteLine("Fim de operação do sistema");
}


public class Usuarios
{
    public string Nome { get; set; }//  get = puxa o valor
    public int Idade { get; set; } // set = define o valor

    public Usuarios(string nome, int idade)
    {
        if (nome.Length == 0)
        {
            throw new NomeInvalidoException("O nome é obrigatório");
        }
        if (nome.All(char.IsDigit))
        {
            throw new NomeInvalidoException("O nome não pode ser números");
        }


        if (idade > 150)
        {
            throw new IdadeInvalidaException("Idade não muito elevada ");
        }
        if (idade < 0)
        {
            throw new IdadeInvalidaException("Idade não muito baixa ");
        }

        Nome = nome;
        Idade = idade;
    }
}


public class IdadeInvalidaException : Exception
{
    public IdadeInvalidaException() { }
    public IdadeInvalidaException(string message) : base(message) { }
    public IdadeInvalidaException(string message, Exception innerException) { }
}

public class NomeInvalidoException : Exception
{
    public NomeInvalidoException() { }
    public NomeInvalidoException(string message) : base(message) { }
    public NomeInvalidoException(string message, Exception innerException) { }
}

/*
 
    class Usuario
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Usuario(string nome, int idade)
        {
            if (idade < 0 || idade > 150) throw new IdadeInvalidaException();

            Nome = nome;
            Idade = idade;
        }
    }

*/