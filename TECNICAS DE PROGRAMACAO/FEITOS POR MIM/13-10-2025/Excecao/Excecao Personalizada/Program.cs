ContaBancaria = new ContaBancaria(300.00m);

try 
{
    conta.Sacar("100");
}
catch(SaldoInsuficienteException ex)
{
    Console.WriteLine("Erro de Saldo:" + ex.Message);
}

try
{
    conta.Sacar("500");
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine("Erro de Saldo:" + ex.Message);
}

try
{
    conta.Sacar("adasdasdasda");
}
catch (ApplicationException ex)
{
    Console.WriteLine(ex.Message);
}

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException() { }
    public SaldoInsuficienteException(string mensagem):base(mensagem) { }
    public SaldoInsuficienteException(string mensagem, Exception innerException) { }
}

public class ContaBancaria
{
    public decimal Saldo { get; private set; }

    public ContaBancaria(decimal saldo)

    public void Sacar(string valorTexto)
    {
        try
        {
            decimal valor = decimal.Parse(valorTexto);
            if(valor > Saldo)
            {
                throw new SaldoInsuficienteException($"Saldo insuficiente. Saldo atual: R${Saldo}. Tentativa de saque no valor de: {valor}");
            }
            Saldo -= valor;
            Console.WriteLine($"Saldo atual: R${Saldo}");
        }
        catch (FormatException fe)
        {
            throw new ApplicationException("Erro ao converter o valor do saque", fe);
        }
        finally
        {
            Console.WriteLine("Fim do saque");
        }
    }
}