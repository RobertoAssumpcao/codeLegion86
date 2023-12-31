<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<br />
<div align="center">
  <h1 align="center">Code Legion 86</h1>

  <p align="center">
    <a href="https://github.com/RobertoAssumpcao/codeLegion86/issues">Report Bug</a>
    ·
    <a href="https://github.com/RobertoAssumpcao/codeLegion86/issues">Request Feature</a>
  </p>
</div>

## Sobre o projeto

Este é um programa de console em C# que utiliza a API GraphQL do [Anilist](https://github.com/AniList/ApiV2-GraphQL-Docs) para recuperar informações de perfil de um usuário.

### Tecnologias

* [CSharp](https://learn.microsoft.com/pt-br/dotnet/csharp/)
* [Json.NET (Newtonsoft.Json)](https://www.newtonsoft.com/json)
* [System.Net.Http](https://learn.microsoft.com/pt-br/dotnet/api/system.net.http?view=net-8.0)

## Configuração

### Pre requisitos

* [SDK .NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* [Newtonsoft.Json 13.0.3](https://www.nuget.org/packages/Newtonsoft.Json/)

## Como usar

O programa irá abrir um terminal, basta passar o User Name do usuario do anilist que ira retornar os dados desse usuário.

### Exemplo
User Name: UsuarioTeste

```json
{
  "data": {
    "User": {
      "id": 0001,
      "name": "UsuarioTeste",
      "about": "Sobre"
    }
  }
}
```

## Contribuição

As contribuições são o que tornam a comunidade de código aberto um lugar incrível para aprender, inspirar e criar. Qualquer contribuição que você fizer será **muito apreciada**.

Se você tiver uma sugestão que possa melhorar isso, crie um fork o repositório e crie uma solicitação pull. Você também pode simplesmente abrir um issue. Não se esqueça de dar uma estrela ao projeto! Obrigado novamente!

1. de um Fork no projeto
2. Crie sua Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push sua Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Licença

Distribuído sob a licença MIT. Consulte `LICENSE.txt` para obter mais informações.

<p align="right">(<a href="#top">back to top</a>)</p>

[contributors-shield]: https://img.shields.io/github/contributors/RobertoAssumpcao/codeLegion86.svg?style=for-the-badge
[contributors-url]: https://github.com/RobertoAssumpcao/codeLegion86/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/RobertoAssumpcao/codeLegion86.svg?style=for-the-badge
[forks-url]: https://github.com/RobertoAssumpcao/codeLegion86/network/members
[stars-shield]: https://img.shields.io/github/stars/RobertoAssumpcao/codeLegion86.svg?style=for-the-badge
[stars-url]: https://github.com/RobertoAssumpcao/codeLegion86/stargazers
[issues-shield]: https://img.shields.io/github/issues/RobertoAssumpcao/codeLegion86.svg?style=for-the-badge
[issues-url]: https://github.com/RobertoAssumpcao/codeLegion86/issues
[license-shield]: https://img.shields.io/github/license/RobertoAssumpcao/codeLegion86.svg?style=for-the-badge
[license-url]: https://github.com/RobertoAssumpcao/codeLegion86/blob/main/LICENSE