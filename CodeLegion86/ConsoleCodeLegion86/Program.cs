using System.Runtime.InteropServices;
using ConsoleCodeLegion86;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

try
{
    Console.WriteLine(@"
░█████╗░░█████╗░██████╗░███████╗██╗░░░░░███████╗░██████╗░██╗░█████╗░███╗░░██╗░█████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔════╝██║░░░░░██╔════╝██╔════╝░██║██╔══██╗████╗░██║██╔══██╗██╔═══╝░
██║░░╚═╝██║░░██║██║░░██║█████╗░░██║░░░░░█████╗░░██║░░██╗░██║██║░░██║██╔██╗██║╚█████╔╝██████╗░
██║░░██╗██║░░██║██║░░██║██╔══╝░░██║░░░░░██╔══╝░░██║░░╚██╗██║██║░░██║██║╚████║██╔══██╗██╔══██╗
╚█████╔╝╚█████╔╝██████╔╝███████╗███████╗███████╗╚██████╔╝██║╚█████╔╝██║░╚███║╚█████╔╝╚█████╔╝
░╚════╝░░╚════╝░╚═════╝░╚══════╝╚══════╝╚══════╝░╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░░╚════╝░");

    QueryUser? queryUser = await GetUsuario();

    if (queryUser?.User?.Id is null || queryUser.User.Id == 0)
    {
        Console.WriteLine("Usuário não pode ser null");
        Environment.Exit(1);
    }
    else
    {
        bool menuOpcao = true;
        do
        {
            Console.WriteLine(@"
            Opções:
            Digite anime para buscar animes
            Digite manga para buscar mangas
            Digite sair para fechar o programa.");
            Console.WriteLine("Escolha uma opção");
            string? opcao = Console.ReadLine();
            if (string.IsNullOrEmpty(opcao))
            {
                Console.WriteLine("Opção inválida");
            }
            switch (opcao?.ToLower())
            {
                case "sair":
                    menuOpcao = false;
                    break;
                case "anime":
                    await GetAnimes(queryUser.User.Id);
                    break;
                case "manga":
                    // Fazer buscar mangá
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        while (menuOpcao);
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Erro na execução: {ex.Message}");
}

static async Task<QueryUser?> GetUsuario()
{
    try
    {

        Console.WriteLine("Digite o User Name");
        string? userName = Console.ReadLine();
        if (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("O nome não pode ser nulo ou vazio. Encerrando o programa.");
            return null;
        }
        else
        {
            var graphQLClient = new GraphQLHttpClient("https://graphql.anilist.co", new NewtonsoftJsonSerializer());
            var response = await graphQLClient.SendQueryAsync<QueryUser>(new GraphQLRequest
            {
                Query = $@"query
                    {{
                        User(name: ""{userName}"") 
                        {{
                            id
                        }}
                    }}"
            });

            if (response.Errors is not null)
            {
                Console.WriteLine("Erro na consulta GraphQL:");
                foreach (var error in response.Errors)
                {
                    Console.WriteLine(error.Message);
                }
                return null;
            }
            else
            {
                return response.Data;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro {ex.Message} ao buscar usuario.");
        return null;
    }
}

static async Task<QueryAnime?> GetAnimes(int id)
{
    try
    {
        var graphQLClient = new GraphQLHttpClient("https://graphql.anilist.co", new NewtonsoftJsonSerializer());
            var response = await graphQLClient.SendQueryAsync<QueryAnime>(new GraphQLRequest
            {
                Query = $@"query
                    {{

                    }}"
            });

            if (response.Errors is not null)
            {
                Console.WriteLine("Erro na consulta GraphQL:");
                foreach (var error in response.Errors)
                {
                    Console.WriteLine(error.Message);
                }
                return null;
            }
            else
            {
                return response.Data;
            }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro {ex.Message} ao buscar usuario.");
        return null;
    }
}