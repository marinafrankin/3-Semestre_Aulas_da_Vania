

//  EXCEÇÃO

try 
{ 
    Console.WriteLine("Digite o dividendo");
    int dividendo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Digite o divisor");
    int divisor = Convert.ToInt32(Console.ReadLine());
    int resultado = dividendo / divisor;
    Console.WriteLine($"O resultado de {dividendo} / {divisor} = {resultado}");
}

//catch (FormatException)
//{
//    Console.WriteLine("Digite um número inteiro, zé");
//}

catch (Exception ex) when (ex.Message.Contains("format"))
{
    Console.WriteLine(ex.Message);
}

catch (OverflowException)
{
    Console.WriteLine("Digite um número de 1 a 9999");
}

catch (DivideByZeroException)
{
    Console.WriteLine("O divisor não pode ser zero, sua anta");
}

catch (Exception ex)
{
    Console.WriteLine("Divisor finalizada");
}