# ScoreAPIClient

API desenvolvida em **.NET 10** para cadastro de clientes e cálculo de Score de Confiança.

Este projeto foi desenvolvido como solução para um desafio, mantendo a arquitetura proposta e implementando a persistência em **SQL Server** utilizando **ADO.NET**, sem utilização de Entity Framework ou Dapper.

### Observações

A implementação manteve as regras de negócio existentes e adicionou apenas a camada de persistência em banco de dados, conforme solicitado no desafio.

---

# Tecnologias

- .NET 10
- ASP.NET Core Web API
- SQL Server
- ADO.NET
- Swagger (OpenAPI)

---

# Arquitetura

O projeto segue uma arquitetura em camadas, separando responsabilidades entre API, aplicação, domínio e infraestrutura.

```
Request
   │
   ▼
API
(Controllers / Middlewares)
   │
   ▼
Application
(Services / Contracts)
   │
   ▼
Domain
(Entities / Interfaces)
   │
   ▼
Infrastructure
(Data / Repositories / SQL / Mappers)
```

Estrutura do projeto:

```
API
│
├── Controllers
├── Middlewares
│
Application
│
├── Contracts
├── Services
│
Domain
│
├── Entities
└── Interfaces
│
Infrastructure
│
├── Data
│   └── ConnectionFactory.cs
│
├── Repositories
│   └── CustomerSqlRepository.cs
│   └── CustomerSqlQueries.cs
│
└── Mappers
    └── CustomerMapper.cs
```

---

# Funcionalidades

- Cadastro de clientes
- Consulta por CPF
- Listagem de clientes
- Atualização de clientes
- Validação de CPF
- Validação de renda anual
- Validação de data de nascimento
- Cálculo automático do Score

---

# Persistência

A persistência foi implementada utilizando:

- SQL Server
- ADO.NET
- SqlConnection
- SqlCommand
- SqlParameter
- SqlDataReader

Não foi utilizado:

- Entity Framework
- Dapper
- Qualquer ORM

---

# Banco de Dados

Os scripts de criação do banco encontram-se na pasta:

```
Scripts/
```

Executar os scripts na seguinte ordem:

```
001_CreateDatabase.sql

002_CreateTables.sql

```

Após a execução, configure a Connection String no arquivo:

```
appsettings.json
```

Exemplo:

```json
"ConnectionStrings": {
  "Connection": "Server=.;Database=ScoreAPI;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

# Como executar

Restaurar os pacotes:

```bash
dotnet restore
```

Executar a aplicação:

```bash
dotnet run
```

Abrir o Swagger:

```
http://localhost:<porta>/swagger
```

---

# Estrutura dos Commits

Durante o desenvolvimento procurei dividir a implementação em pequenas etapas para facilitar a revisão do código.

```
chore: configure database infrastructure

feat: add database initialization script

feat: create SQL Server customer repository

feat: implement customer creation

feat: implement customer queries

feat: implement customer update

refactor: replace in-memory persistence with SQL Server

docs: add database setup instructions
```

---

# Melhorias Futuras

- Autenticação JWT
- Logs estruturados
- Testes Unitários
- Testes de Integração
- Docker
- CI/CD
- Health Checks
- Rate Limiting

---

# Princípios utilizados

- SOLID
- Clean Code
- Separation of Concerns
- Dependency Injection
- Repository Pattern
- Clean Architecture

---

