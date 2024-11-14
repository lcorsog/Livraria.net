# Livraria API

Esta é uma API RESTful construída com ASP.NET Core para gerenciar uma biblioteca de livros. A aplicação permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) em um banco de dados SQL Server Developer Edition, utilizando o Entity Framework Core como ORM para acesso e manipulação dos dados. Além disso, a aplicação implementa o padrão MVC para consumir essa API RESTful através de views, permitindo uma interface de usuário para realizar as operações de gerenciamento de livros.

## Tecnologias Utilizadas

- **ASP.NET Core** - Framework para construção de aplicações web e APIs.
- **Entity Framework Core** - ORM para interação com o banco de dados.
- **SQL Server Developer Edition** - Banco de dados para armazenamento dos dados dos livros.
- **Swagger** - Para documentação interativa da API (opcional).

## Funcionalidades da API

A API possui endpoints para gerenciar uma biblioteca de livros, permitindo:

- **Criar** um novo livro.
- **Consultar** todos os livros ou um livro específico por ID.
- **Atualizar** dados de um livro existente.
- **Deletar** um livro do sistema.

## Pré-requisitos

Antes de iniciar, verifique se você possui os seguintes pré-requisitos instalados:

- [.NET SDK (versão mais recente)](https://dotnet.microsoft.com/download)
- [SQL Server Developer Edition](https://www.microsoft.com/sql-server/sql-server-downloads)
- [Visual Studio 2022 ou Visual Studio Code](https://visualstudio.microsoft.com/) com suporte para desenvolvimento em ASP.NET Core.

## Como Configurar o Projeto

1. **Clone o repositório**

   ```bash
   git clone https://github.com/lcorsog/Livraria.net.git
   cd Livraria.net
   ```

2. **Configure o Banco de Dados**

   - No SQL Server, crie um banco de dados chamado `LivrariaDb` ou qualquer outro nome de sua escolha.
   - Encontre a string de conexão do seu banco de dados em Server Explorer, dentro de propriedades do banco conectado.
   - Atualize a string de conexão no arquivo `appsettings.json` para apontar para o banco de dados criado. Exemplo de string de conexão:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=LivrariaDb;User Id=seu-usuario;Password=sua-senha;"
     }
     ```

3. **Instale as Dependências**

   No diretório do projeto, execute o seguinte comando para restaurar os pacotes necessários:

   ```bash
   dotnet restore
   ```

4. **Execute as Migrações**

   A aplicação utiliza o Entity Framework Core para gerenciar o banco de dados. Para aplicar as migrações e criar as tabelas, execute:

   ```bash
   dotnet ef database update
   ```

   > Certifique-se de que o SQL Server está em execução e que a string de conexão no `appsettings.json` está correta.

5. **Compile e Execute a Aplicação**

   Para iniciar o servidor, execute:

   ```bash
   dotnet run
   ```

   A API estará disponível em `https://localhost:5001` ou `http://localhost:5000` (as portas podem variar).

6. **Acessar a Documentação Swagger**

   Com a aplicação em execução, você pode acessar a documentação interativa da API gerada pelo Swagger em `https://localhost:5001/swagger` ou `http://localhost:5000/swagger`.

## Endpoints da API

| Método | Endpoint          | Descrição                            |
|--------|--------------------|--------------------------------------|
| GET    | /api/Book/Get     | Retorna todos os livros.            |
| GET    | /api/Book/Get/{id}| Retorna um livro pelo ID.           |
| POST   | /api/Book/Post    | Cria um novo livro.                 |
| PUT    | /api/Book/Put     | Atualiza os dados de um livro.      |
| DELETE | /api/Book/Delete/{id}| Deleta um livro pelo ID.         |

## Ponto de atenção

Dentro de BookController (ConsumeWebAPI) confira se Uri baseAddress = new Uri("https://localhost:7080/api"); está apontando para a porta https correta.

Você pode conferir a porta https no arquivo launchSettings.json dentro da pasta Properties (CRUDWithWebApi).
