Console.WriteLine("Iniciando o Pedido");
Pedido pedido = new Pedido();
//registra os assinantes
pedido.OnCriarPedido += EnviarEmail.Email;
pedido.OnCriarPedido += EnviarSMS.SMS;

//criar o pedido

pedido.CriarPedido();
Console.WriteLine("Finalizando o Pedido");

Console.ReadKey();

public delegate void PedidoEvent();
class Pedido
{
    public event PedidoEvent? OnCriarPedido;

    public void CriarPedido()
    {
        Console.WriteLine("Pedido sendo criado");
        if(OnCriarPedido != null)
        {
            OnCriarPedido();
        }
    }
}//fim da classe pedido
class EnviarEmail
{
    public static void Email()
    {
        Console.WriteLine("Email enviado");
    }
}//fim da classe
class EnviarSMS
{
    public static void SMS()
    {
        Console.WriteLine("SMS enviado");
    }
}

