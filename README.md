# Investimentos

Este projeto faz parte do Sprint 3 da disciplina de C#.

## Descrição

O projeto `Investimentos` é uma aplicação desenvolvida em C# que tem como objetivo gerenciar diferentes tipos de investimentos. Ele utiliza uma arquitetura baseada em repositórios e modelos, facilitando a manutenção e a escalabilidade do código.

## Estrutura do Projeto

- **Program.cs**: Ponto de entrada da aplicação.
- **Models/Investimento.cs**: Define a estrutura dos investimentos.
- **Repositories/InvestimentoRepository.cs**: Responsável pelo acesso e manipulação dos dados dos investimentos.
- **appsettings.json / appsettings.Development.json**: Configurações da aplicação.
- **wwwroot/**: Arquivos estáticos (HTML, SVG, etc).

## Como Executar

1. Certifique-se de ter o .NET 9.0 SDK instalado.
2. No terminal, navegue até a pasta `Investimentos`.
3. Execute o comando:
   ```powershell
   dotnet run
   ```
4. Acesse a aplicação conforme instruções do terminal.

## Dependências

- .NET 9.0
- Npgsql (para acesso a banco de dados PostgreSQL)

## Observações

- O projeto está configurado para ambiente de desenvolvimento e produção.
- Os arquivos de configuração podem ser ajustados conforme necessário.

## Autor

Sprint 3 - C#
