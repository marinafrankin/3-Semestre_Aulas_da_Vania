
try
{
    A.ProcessarA();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


class A
{
    public static void ProcessarA()
    {
        //try
        //{
            B.ProcessarB();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
    }
}

class B
{
    public static void ProcessarB()
    {
        //try
        //{
            C.ProcessarC();
        //}
        //catch (Exception ex)
        //{ 
        //    Console.WriteLine(ex.Message);
        //}
    }
}

class C
{
    public static void ProcessarC()
    {
        throw new NotImplementedException("Método não implementado");
    }
}