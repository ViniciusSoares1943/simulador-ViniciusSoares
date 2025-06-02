# Simulador de Crédito

**Teste técnico Sicoob Engecred - Vinicius Correia Soares**

A descrição dos requisitos e orientações do teste técnico se encontra no arquivo [`TesteTecnicoSicoobEngecred.pdf`](./TesteTecnicoSicoobEngecred.pdf)

Este projeto é composto por uma aplicação **frontend Angular 17**, uma **API .NET 8** e um **banco de dados SQL Server**, todos orquestrados via Docker Compose.

---

## 📦 Estrutura dos Serviços

| Serviço   | Imagem/Base              | Porta Externa | Porta Interna | Função                            |
|-----------|---------------------------|----------------|----------------|-----------------------------------|
| frontend  | NGINX + Angular           | 8080           | 80             | Interface Web do simulador        |
| backend   | .NET 8 API                | 8001           | 80             | API que processa as requisições   |
| sqlserver | Microsoft SQL Server 2022 | 1433           | 1433           | Banco de dados relacional         |

---

## 🚀 Como Executar

### Pré-requisitos

- Docker
- Docker Compose

### Passos

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/ViniciusSoares1943/simulador-ViniciusSoares.git
   cd simulador-ViniciusSoares
   ```

2. **Execute os containers:**

   ```bash
   docker compose up -d
   ```
   Obs: Ao executar pela primeira vez pode demorar um pouco a depender da conexão de rede para baixar as imagens
   
4. **Acesse os serviços:**

   - Frontend: [http://localhost:8080](http://localhost:8080)
   - Backend (API): [http://localhost:8001/swagger/index.html](http://localhost:8001/swagger/index.html)

---

## 🌐 Rotas e Acesso

### 🔹 Frontend Angular (Interface Web)

- URL: [http://localhost:8080](http://localhost:8080)

### 🔹 Backend .NET API

- URL base: `http://localhost:8001/swagger/index.html`
- Documentação via swagger

   Para modelagem dos dados foram criadas três tabelas : Produtos, Segmentos e TaxaCredito.
   Que, por sua vez foram criados rotas de um CRUD simples para testar funcionalidades.

   Os dados da planilha foram gerados por uma seed e inseridos no banco via migrations do ef core (que é executada ao inicializar a aplicação)

   Foram criados teste unitários usando XUnit, que podem ser executados com o seguinte comando na pasta SimuladorCredito.Api
   ```bash
   dotnet test
   ```
   
   O FrontEnd consome apenas duas rotas : "/api/Produto/ObterPorTipoPessoa" e "/api/TaxaCredito/SimularCredito".
   
   Todas as rotas possuem descrição, schemas de entrada e retorno via swagger, também não possuem autenticação.

   O BackEnd possui logs de nível information e error, que podem ser visualizados no console do container com o seguinte comando:
   ```bash
   docker logs backendApi
   ```

   A exibição deve ser algo semelhante a :
   ```bash
   2025-06-02 00:51:30.8359 | INFO | Taxa de crédito obtida com sucesso.
   ```

   Considerações técnicas

   * Padrão Repositories - Para separação de responsabilidades, deixando toda a parte de negócio e lógica no services.

   * BackEnd em português, não tenho preferência por idioma na nomeclatura de métodos, rotas, variáveis, classes e etc. Aderi o português por achar ser de fácil entendimento. O FrontEnd permaneceu completo em inglês.

   * Seeds e migrations - Optei por utilizar o EntityFramework como ORM por ter mais familiariedade e ser a opção mais utilizada, o recurso de seeds do efcore é simples e fácil de implementar para inserir os dados iniciais.

---

## 🗃️ Banco de Dados

- **Tipo**: SQL Server 2022
- **Host**: `localhost`
- **Porta**: `1433`
- **Usuário**: `sa`
- **Senha**: `SimuladorCredito2025!`
- **Database**: `master` 

---
