
Console.WriteLine("Iniciando o pedido");
Pedido pedido = new Pedido();
// Registrar os assinantes
pedido.OnCriarPedido += EnviarEmail.Email; // o += ele acrecenta um assinate
pedido.OnCriarPedido -= EnviarSMS.SMS; // o -= ele retira um acinante
pedido.OnCriarPedido += PedidoPendente.Pendente; 

// criar o pedido
pedido.CriarPedido();
Console.WriteLine("Finalizando pedido");

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
}
// Fim da classe Pedido


class EnviarEmail
{
    public static void Email()
    {
        Console.WriteLine("Email enviado");
    }
}
// Fim da classe EnviarEmail


class EnviarSMS
{
    public static void SMS()
    {
        Console.WriteLine("SMS enviado");
    }
}
// Fim da classe EnviarSMS

class PedidoPendente
{
    public static void Pendente()
    {
        Console.WriteLine("Pedido pendente");
    }
}