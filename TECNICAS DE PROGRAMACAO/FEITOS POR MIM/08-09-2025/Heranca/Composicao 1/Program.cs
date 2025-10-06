Carro car = new Carro("Fiat", "Toro volcano", "V8", "2.0");

Console.WriteLine($"Marca: {car.Marca}, Modelo: {car.Modelo}, \nMotor:\nTipo: {car.MotorCarro.Tipo}, Potência: {car.MotorCarro.Potencia}");


class Carro
{
    public string Marca {  get; set; }
    public string Modelo { get; set; }

    public Motor MotorCarro { get; set; }

    public Carro(string marca, string modelo, string tipo, string potencia)
    {
        Marca = marca;
        Modelo = modelo;
        MotorCarro = new Motor(tipo, potencia);
    }
}

class Motor
{
    public string Tipo {  get; set; }
    public string Potencia { get; set; }

    public Motor(string tipo, string potencia)
    {
        Tipo = tipo;
        Potencia = potencia;
    }
}