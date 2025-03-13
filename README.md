[![.NET](https://github.com/WGMartins/fiap-tech-challenge-net/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/WGMartins/fiap-tech-challenge-net/actions/workflows/dotnet.yml)

# FIAP Tech Challenge

## Tema

O Tech Challenge desta fase será desenvolver um aplicativo utilizando a plataforma .NET 8 para cadastro de contatos regionais, considerando a persistência de dados e a qualidade do software.

## Tecnologias Utilizadas
- .NET Core 8.0
  -  .NET 8.0 é a versão mais recente da plataforma de desenvolvimento, oferecendo recursos avançados para construir aplicações modernas e robustas.
    -  Apresenta melhorias significativas de desempenho, com otimizações que tornam as aplicações mais rápidas e eficientes.
    -  Inclui suporte a novas APIs e melhorias na linguagem C#, facilitando o desenvolvimento e a manutenção do código.
    -  Traz melhorias em segurança, fundamentais para proteger dados sensíveis, como os contatos armazenados na aplicação.

- BD Postgres
  - PostgreSQL é um sistema de gerenciamento de banco de dados relacional de código aberto, amplamente utilizado por sua robustez e suporte a tipos de dados avançados.
    - Suporte a transações e integridade referencial.
    - Capacidade de escalar horizontalmente.
    - Flexibilidade para lidar com consultas complexas.
  
- FluentValidation
  - FluentValidation é uma biblioteca popular para validação de objetos em aplicações .NET, que permite a definição de regras de validação de forma fluente e intuitiva.
    - Permite criar regras de validação de maneira muito expressiva, melhorando a legibilidade do código.
    - A validação pode ser isolada em classes específicas, promovendo uma arquitetura mais limpa e organizada.
    - Funciona bem com .NET Core, integrando-se facilmente ao pipeline de validação da aplicação.

- EF Core
  - Entity Framework é uma ferramenta de mapeamento objeto-relacional que permite a interação com o banco de dados usando objetos .NET.
    - O desenvolvimento foi feito a partir da definição das classes e modelos de domínio utilizando a abordagem Code First. O banco de dados é gerado a partir dessas definições, permitindo uma maior agilidade nas alterações de modelo.
    - Facilita a criação e manutenção de migrations, garantindo que as alterações no modelo sejam refletidas no banco de dados.

- XUnit
  - XUnit é um framework de testes para .NET que fornece uma maneira simples e eficaz de escrever testes unitários e de integração.
    - Testes são escritos para verificar a lógica de negócios, a integração com o banco de dados e a funcionalidade de armazenamento e recuperação de contatos.
    - Uso de in-memory database do Entity Framework para simular operações sem a necessidade de um banco de dados real, o que permite uma execução rápida dos testes.
   
- Prometheus
    - Prometheus é uma ferramenta open-source de monitoramento que coleta e armazena métricas em séries temporais. É amplamente utilizado em ambientes de microserviços e Kubernetes.
      
- Grafana
    - O Grafana é uma plataforma open-source de visualização de dados, usada para criar dashboards interativos e gráficos em tempo real. Ele se integra com diversas fontes de dados, como Prometheus, InfluxDB e Elasticsearch. É amplamente utilizado para monitoramento de sistemas e análise de métricas.

## Configuração do Banco de dados

Para criação e configuração dos bancos de dados devem ser executados comandos abaixo. 

```
docker pull postgres:latest
```
```
docker run --name db-local -e POSTGRES_PASSWORD=102030 -d -p 5432:5432 postgres
```

PS.: É necessário que máquina possua Docker instalado

## Execução de migration do Banco de dados

Para criação e atualização do migration no banco de dados da aplicação devem ser seguidos os comandos abaixo.

```
Update-Database -Project TechChallenge.Infrastructure -StartupProject TechChallenge.Infrastructure -Connection "Host=localhost;Port=5432;Database=TechChallenge;User ID=postgres;Password=102030;Pooling=true;Connection Lifetime=0;"
```

## Configuração de coleta de métricas

Executar os comandos abaixo para subir as imagens do postgres, prometheus e grafana.

PS.: Na primeira execução da aplicação é necessário configurar a base de dados através do migration descrito na seção anterior
```
docker compose build
```
```
docker compose up
```
