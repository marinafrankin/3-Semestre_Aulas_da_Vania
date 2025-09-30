int idade = 21;
string nome = "Vera";
float peso = 52.5f;
decimal salario = 5245.6m;
double bonus = 50.0;

// concatenação
Console.WriteLine("Nome: " + nome);
Console.WriteLine("Idade: " + idade);

// interpolação
Console.WriteLine($"Peso: {peso}");
Console.WriteLine($"Salário: " + salario);

// conversões implícitas - naturalmente de um tipo para outro
int x = 123;
double y = x;

// conversões explícitas - cast
int z = 2;
int w = 3;
float k = (float) z / w;

// funções - ToString
int ex1 = 1;
string txt = ex1.ToString();

// funções - ReadLine
Console.WriteLine("Digite a sua idade: ");
int idade2 = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o seu peso: ");
double peso2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"Idade: {idade2}");
Console.WriteLine($"Peso: {peso2}");

// nullable
int? numero2 = null; // se torna um tipo diferente de int, que pode ser nulo
int numero1 = numero2 ?? 0; // se numero2 for numero atribui valor ao numero1, caso não, o valor é 0 (nesse caso é NULO, não número)
Console.WriteLine(numero1);

string produto = "";
Console.WriteLine($"Produto: {produto.ToUpper()}");

// operador ternário
var tempo = 16.5;
var resultado = tempo > 27 ? "calor" : "frio"; // se for verdadeiro, avança para após o '?', se não, avança para após o ':'
Console.WriteLine(resultado);
