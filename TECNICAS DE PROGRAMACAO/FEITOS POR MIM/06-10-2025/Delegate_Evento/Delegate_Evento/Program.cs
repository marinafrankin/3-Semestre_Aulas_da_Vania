//três formas diferentes de usar o delegate com o método
MeuDelegate del1 = new MeuDelegate(MeuMetodo);
MeuDelegate del2 = MeuMetodo;
MeuDelegate del3 = (msg) => Console.WriteLine(msg);

del1("Bom dia");
del2("Boa tarde");
del3("Boa noite");
static void MeuMetodo(string mensagem)
{
    Console.WriteLine(mensagem);
}
Console.ReadKey();
public delegate void MeuDelegate(string msg);