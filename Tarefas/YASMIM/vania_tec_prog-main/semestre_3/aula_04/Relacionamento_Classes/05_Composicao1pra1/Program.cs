Carro carro = new Carro("Fiat", "Toro volcano", "V8", "2.0");

Console.WriteLine($"Marca: {carro.Marca}\nModelo: {carro.Modelo}");
Console.WriteLine($"--- Motor ---\nTipo: {carro.Motor.Tipo}\nPotência: {carro.Motor.Potencia}");

// Composição 1 pra 1
// Todo: carro
class Carro
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public Motor Motor { get; set; }

    public Carro(string marca, string modelo, string tipo, string potencia)
    {
        Marca = marca;
        Modelo = modelo;
        Motor = new Motor(tipo, potencia); // Necessário instanciar para criar
    }
}

// Parte: motor
class Motor
{
    public string Tipo { get; set; }
    public string Potencia { get; set; }

    public Motor(string tipo, string potencia)
    {
        Tipo = tipo;
        Potencia = potencia;
    }
}