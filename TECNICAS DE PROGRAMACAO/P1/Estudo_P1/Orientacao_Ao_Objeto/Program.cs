

/*

    ORIENTAÇÃO AO OBJETO

Crie uma classe chamada Funcionario que contenha:
Três construtores:
    Um vazio.
    Um que receba apenas o nome.
    Um que receba nome, salário e cargo.
    Uma propriedade Salario que não permita valores menores que 1.200.
    Uma propriedade somente leitura Bonus, que retorne 10% do salário.
    Um método Exibir() que mostre todas as informações do funcionário.

No Main, crie pelo menos dois objetos usando construtores diferentes e chame o método Exibir().
 
*/

Funcionario fun1 = new Funcionario("Carlos", 1204, "Funcionario 01");
Funcionario fun2 = new ("Amanda", 1500, "Gerente");
var fun3 = new Funcionario();

fun1.Exibir();
fun2.Exibir();


Console.ReadKey();


public class Funcionario
{

    public Funcionario(string nome)
    {
        Nome = nome;
    }

    public Funcionario(string nome, double salario, string cargo)
    {
        Nome = nome;
        this.Salario = salario;
        Cargo = cargo;

    }

    public Funcionario() { }


    // SALARIO
    private double salario;
    public double Salario
    {
        get { return salario; }
        set
        {
            if (value < 1200)
            {
                salario = 1200;
            }
            else
            {
                salario = value;
            }
        }
    }

    //  NOME
    private string? nome;
    public string? Nome
    {
        get { return nome.ToUpper(); }
        set { nome = value; }
    }

    //  CARGO
    private string? cargo;
    public string? Cargo
    {
        get { return cargo.ToUpper(); }
        set { cargo = value; }
    }

    private double Bonus { get { return Salario * 0.1; } }


    public void Exibir()
    {
        Console.WriteLine($"{Nome}" +
            $"\n{salario.ToString("c")}" +
            $"\n{Cargo}");
    }
}