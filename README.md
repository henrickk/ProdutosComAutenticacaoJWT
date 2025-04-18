# ProdutosComAutenticacaoJWT

Este é um projeto ASP.NET Core que implementa uma API para gerenciamento de produtos com autenticação baseada em JWT (JSON Web Token). O projeto utiliza o Identity para gerenciar usuários e autenticação.

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **JWT (JSON Web Token)**
- **Microsoft Identity**
- **Banco de Dados Relacional (SQLite por padrão)**

## Funcionalidades

- Registro de usuários com validação de senha.
- Login de usuários com geração de tokens JWT.
- Autenticação e autorização baseada em roles.
- CRUD de produtos protegido por autenticação.

## Estrutura do Projeto

- **Controllers**: Contém os controladores da API, como `AuthController` e `ProdutosController`.
- **Models**: Contém os modelos de dados, como `RegisterUserViewModel`, `LoginUserViewModel`, `JwtSettings` e `Produto`.
- **Data**: Contém o contexto do banco de dados (`ApiDbContext`) e as migrações.
- **Migrations**: Contém as migrações do Entity Framework Core.
- **appsettings.json**: Configurações do projeto, incluindo as configurações do JWT.

## Configuração do Projeto

### Pré-requisitos

- .NET 8 SDK instalado.
- Banco de dados SQLite ou outro banco configurado no `appsettings.json`.

### Configuração do JWT

No arquivo `appsettings.json`, configure as propriedades do JWT:

"JwtSettings": { "Segredo": "sua-chave-secreta-aqui", "TempoExpiracao": 2, "Emissor": "SeuEmissor", "Audience": "SuaAudiencia" }


- **Segredo**: Chave secreta usada para assinar o token.
- **TempoExpiracao**: Tempo de expiração do token em horas.
- **Emissor**: Identificador do emissor do token.
- **Audience**: Identificador do público-alvo do token.

### Configuração do Banco de Dados

Por padrão, o projeto utiliza SQLite. No arquivo `appsettings.json`, configure a string de conexão:

"ConnectionStrings": { "DefaultConnection": "Data Source=produtos.db" }


### Executando o Projeto

1. Restaure as dependências:
   dotnet restore

2. Aplique as migrações para criar o banco de dados:
   dotnet ef database update

3. Execute o projeto:
   dotnet run


A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## Endpoints da API

### Autenticação

- **POST /api/auth/register**  
  Registra um novo usuário.  
  **Body**:
  { "email": "usuario@exemplo.com", "password": "Senha123!", "confirmPassword": "Senha123!" }

  
- **POST /api/auth/login**  
  Realiza login e retorna um token JWT.  
  **Body**:
  { "email": "usuario@exemplo.com", "password": "Senha123!" }

  
### Produtos

- **GET /api/produtos**  
  Retorna a lista de produtos (requer autenticação).

- **POST /api/produtos**  
  Adiciona um novo produto (requer autenticação).  
  **Body**:
  { "nome": "Produto Exemplo", "preco": 100.0 }

  
- **PUT /api/produtos/{id}**  
  Atualiza um produto existente (requer autenticação).

- **DELETE /api/produtos/{id}**  
  Remove um produto (requer autenticação).

## Testando a API

Você pode testar a API utilizando ferramentas como [Postman](https://www.postman.com/) ou [Insomnia](https://insomnia.rest/). Certifique-se de incluir o token JWT no cabeçalho `Authorization` para endpoints protegidos:

Authorization: Bearer {seu_token_jwt}


## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
