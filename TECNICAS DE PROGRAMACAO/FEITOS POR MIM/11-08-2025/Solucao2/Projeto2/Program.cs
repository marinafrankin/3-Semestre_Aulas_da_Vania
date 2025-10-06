int idade = 20;
string nome = "Vara";
float peso = 52.5f;
decimal peso2 = 45.6m;
double peso3 = 75.7;

// Concatenando
wl("Nome: " + nome + "\nIdade: " + idade);


// Interpolando
wl($"Nome: {nome}\nIdade:{idade}\nPeso:{peso}");


// Conversoes 

// Implicitas - feita naturalmente de um tipo para o outro
int x = 123;
double y = x;

// Explicitas - Cast 
int z = 2;
int w = 3;

//Funçoes
string numero = x.ToString();
Console.ReadLine("Digite sua idade: ");
int idade2 = int.Parse(Console.ReadLine());
Console.ReadLine("Digite seu peso: ");
int peso5 = Convert.ToDouble(Console.ReadLine(""));
Console.WriteLine($"Idade: {idade2}");
Console.WriteLine($"Peso: {peso5}");

//nullable
int? numero2 = null;

int numero1 = numero2 ?? 0;

Console.WriteLine(numero1);

string? produto = null;

Console.WriteLine($"Produto: {produto.ToUpper()}");


// Operador ternario
var tempo = 16.5;

var resultado = tempo > 27 ? "calor" : "frio";

Console.WriteLine(resultado);


//float k = (float)z / w