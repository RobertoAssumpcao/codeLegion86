using Newtonsoft.Json;
using System.Text;

Console.WriteLine(@"
░█████╗░░█████╗░██████╗░███████╗██╗░░░░░███████╗░██████╗░██╗░█████╗░███╗░░██╗░█████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔════╝██║░░░░░██╔════╝██╔════╝░██║██╔══██╗████╗░██║██╔══██╗██╔═══╝░
██║░░╚═╝██║░░██║██║░░██║█████╗░░██║░░░░░█████╗░░██║░░██╗░██║██║░░██║██╔██╗██║╚█████╔╝██████╗░
██║░░██╗██║░░██║██║░░██║██╔══╝░░██║░░░░░██╔══╝░░██║░░╚██╗██║██║░░██║██║╚████║██╔══██╗██╔══██╗
╚█████╔╝╚█████╔╝██████╔╝███████╗███████╗███████╗╚██████╔╝██║╚█████╔╝██║░╚███║╚█████╔╝╚█████╔╝
░╚════╝░░╚════╝░╚═════╝░╚══════╝╚══════╝╚══════╝░╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░░╚════╝░");
Console.WriteLine("Digite o nome do usuário");
string? nomeUsuario = Console.ReadLine();

if (string.IsNullOrEmpty(nomeUsuario))
{
    Console.WriteLine("Nome Inválido");
}
else
{
    using HttpClient client = new();
    string jsonRequest = JsonConvert.SerializeObject(new
    {
        query = $@"
            {{
                User(name: ""{nomeUsuario}"") {{
                    id
                    name
                    about
                    avatar {{
                    large
                    medium
                    }}
                }}
            }}"
    });

    var httpRequest = new HttpRequestMessage
    {
        RequestUri = new Uri("https://graphql.anilist.co"),
        Method = HttpMethod.Post,
        Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
    };

    HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
    httpResponse.EnsureSuccessStatusCode();

    string? jsonResponse = await httpResponse.Content.ReadAsStringAsync();

    if (string.IsNullOrEmpty(jsonResponse))
    {
        Console.WriteLine("Erro interno.");
    }
    else
    {
        dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
        Console.WriteLine(responseObject);
    }
}