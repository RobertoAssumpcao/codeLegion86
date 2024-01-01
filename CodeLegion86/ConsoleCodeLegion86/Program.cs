using ConsoleCodeLegion86;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

try
{
    bool menuPrincipal = true;

    do
    {
        Console.Clear();
        Console.WriteLine(@"
░█████╗░░█████╗░██████╗░███████╗██╗░░░░░███████╗░██████╗░██╗░█████╗░███╗░░██╗░█████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔════╝██║░░░░░██╔════╝██╔════╝░██║██╔══██╗████╗░██║██╔══██╗██╔═══╝░
██║░░╚═╝██║░░██║██║░░██║█████╗░░██║░░░░░█████╗░░██║░░██╗░██║██║░░██║██╔██╗██║╚█████╔╝██████╗░
██║░░██╗██║░░██║██║░░██║██╔══╝░░██║░░░░░██╔══╝░░██║░░╚██╗██║██║░░██║██║╚████║██╔══██╗██╔══██╗
╚█████╔╝╚█████╔╝██████╔╝███████╗███████╗███████╗╚██████╔╝██║╚█████╔╝██║░╚███║╚█████╔╝╚█████╔╝
░╚════╝░░╚════╝░╚═════╝░╚══════╝╚══════╝╚══════╝░╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░░╚════╝░");

        Console.WriteLine("Digite buscar para ir ao menu de busca ou digite sair para encerrar o programa.");
        string? opcaoMenuPrincipal = Console.ReadLine();
        if (string.IsNullOrEmpty(opcaoMenuPrincipal))
        {
            Console.WriteLine("Opção inválida");
        }
        else
        {
            switch (opcaoMenuPrincipal?.ToLower())
            {
                case "buscar":
                    bool buscaUsuario = true;
                    QueryUser? queryUser = null;
                    do
                    {
                        queryUser = await GetUsuario();
                        if (queryUser?.User?.Id is null || queryUser.User.Id == 0 || string.IsNullOrEmpty(queryUser?.User?.Name))
                        {
                            Console.WriteLine("Usuário não encontrado. Tente novamente.");
                        }
                        else
                        {
                            buscaUsuario = false;
                        }
                    }
                    while (buscaUsuario);

                    bool menuBuscaLista = true;
                    do
                    {
                        Console.WriteLine("Opções:\n Digite anime para buscar animes\n Digite manga para buscar mangas\n Digite sair para fechar o programa.");
                        Console.WriteLine("Escolha uma opção");
                        string? opcaoBuscaLista = Console.ReadLine();
                        switch (opcaoBuscaLista?.ToLower())
                        {
                            case "sair":
                                menuBuscaLista = false;
                                break;
                            case "anime":
                                QueryAnime? queryAnime = await GetAnimes(queryUser!.User!.Id, queryUser!.User!.Name!);
                                break;
                            case "manga":

                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                Console.WriteLine("Aperte uma tecla para tentar novamente.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    while (menuBuscaLista);
                    break;
                case "sair":
                    Console.WriteLine("Encerrando programa.");
                    menuPrincipal = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte uma tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    while (menuPrincipal);
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
            Console.WriteLine("O nome não pode ser nulo ou vazio.");
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
                            name
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

static async Task<QueryAnime?> GetAnimes(int id, string name)
{
    try
    {
        var graphQLClient = new GraphQLHttpClient("https://graphql.anilist.co", new NewtonsoftJsonSerializer());
        var response = await graphQLClient.SendQueryAsync<QueryAnime>(new GraphQLRequest
        {
            Query = $@"query
                    {{
                        MediaListCollection(userId: {id}, userName: ""{name}"", type: ANIME)
                        {{
                            lists
                            {{
                                name
                            }}
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
    catch (Exception ex)
    {
        Console.WriteLine($"Erro {ex.Message} ao buscar usuario.");
        return null;
    }
}