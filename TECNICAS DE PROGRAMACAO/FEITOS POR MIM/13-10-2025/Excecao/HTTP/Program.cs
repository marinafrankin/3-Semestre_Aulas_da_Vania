

try
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = client.GetAsync("https://fatecjahu.edu.br/livros.txt").Result; // https://www.curseforge.com/minecraft
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Acesso: {response.StatusCode} ");
        Console.WriteLine($"Código: {(int)response.StatusCode} ");
    }
    else
    {
        throw new HttpRequestException("Erro:" + (int)response.StatusCode);
    }
}

catch (HttpRequestException ex) when (ex.Message.Contains("404"))
{
    Console.WriteLine("Página não encontrada");
}
catch (HttpRequestException ex) when (ex.Message.Contains("403"))
{
    Console.WriteLine("Página não autorizada");
}

finally
{
    Console.WriteLine("Fim da requisição");
}
