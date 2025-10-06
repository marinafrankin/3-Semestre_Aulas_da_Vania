Console.WriteLine("Usando evento");
Pedido pedido = new Pedido();
//registrar as classes assinantes
pedido.OnCriarPedido += EnviarEmail.email;
pedido.OnCriarPedido += EnviarSMS.sms;
pedido.criarPedido("maria@gmail.com", "(14)999999999");



class PedidoEventArgs : EventArgs
{
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}
class Pedido
{
    public event EventHandler<PedidoEventArgs>? OnCriarPedido;

    public void criarPedido(string email, string telefone)
    {
        Console.WriteLine("iniciando o criar pedido");
        if (OnCriarPedido != null)
        {
            OnCriarPedido(this, new PedidoEventArgs
            {
                Email = email,
                Telefone = telefone
            }
            );
        }

    }
}
class EnviarEmail
{
    public static void email(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"Email enviado para: {e.Email}");
    }
}
class EnviarSMS
{
    public static void sms(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"SMS enviado para : {e.Telefone}");
    }
}


