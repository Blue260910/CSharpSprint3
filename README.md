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


## Autor

André Lambert – RM 99148
Felipe Cortez - RM 99750
Julia Lins - RM 98690
Luis Barreto - RM 99210
Victor Aranda - RM 99667

## Testes e Dados de Exemplo

Para testar a aplicação, utilize o CPF de exemplo abaixo ao cadastrar ou consultar investimentos:

**CPF para testes:** `526.049.282-38`

Esse CPF já está presente na base de dados de exemplo e pode ser usado para validar as funcionalidades de cadastro, consulta, atualização e remoção de investimentos.

## Arquitetura

O projeto segue o padrão de arquitetura em camadas, separando responsabilidades em:
- **Modelos:** Representação dos dados (pasta Models)
- **Repositórios:** Acesso e manipulação dos dados (pasta Repositories)
- **Program.cs:** Configuração dos endpoints e inicialização da aplicação

### Diagrama das Classes

```mermaid
classDiagram
   class Program {
      +Main()
      +MapGetRoot()
      +MapPostInvestimentos()
      +MapGetInvestimentosPorUsuario()
      +MapPutInvestimentoPorId()
      +MapDeleteInvestimentoPorId()
   }

   class Investimento {
      +Guid Id
      +String UserCpf
      +Guid UserId
      +string Tipo
      +string Codigo
      +decimal Valor
      +string Operacao
      +DateTime CriadoEm
      +DateTime AlteradoEm
   }

   class InvestimentoRepository {
      -string _connectionString
      +InvestimentoRepository(connectionString)
      +InserirInvestimento(Investimento)
      +ListarPorUsuario(string)
      +AtualizarInvestimento(Investimento)
      +DeletarInvestimento(Guid)
   }

   Program --> InvestimentoRepository : usa
   InvestimentoRepository --> Investimento : manipula
```

## Documentação

Todas as principais funcionalidades estão documentadas nos comentários do código e neste README. Para dúvidas, consulte os arquivos fonte ou entre em contato com o autor.
Sprint 3 - C#
