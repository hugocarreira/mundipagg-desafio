# Desafio Mundipagg

## Para rodar o projeto:

- Faça clone do repositório
- Abra a solution e restaure os pacotes do NuGet
- Tenha em sua máquina o ElasticSearch instalado

## A Solution

A solution foi divida pela responsabilidade dos projetos:

- Mundipagg.API = WebAPI
- Mundipagg.API.Tests = Tests unitários em cima da WebAPI
- Mundipagg.Web = Interface Front-End



## Mundipagg.API

- URL: http://localhost:2017



### Tecnologias

> C# como linguagem de programação usando o framework .NET 4.6  
> WebAPi Restful  
> ElasticSearch v5.4.0 - [URL](https://github.com/elastic/elasticsearch)  
> Swashbuckle v5.0 - [URL](https://github.com/domaindrivendev/Swashbuckle/)  



### Aplicação



**Divida Controller**

> POST /api/Divida/setDivida  
> POST /api/Divida/getbyseq
> GET /api/Divida/getDivida  



**Pessoa Controller**

> GET /api/Pessoa/getPessoas  
> POST /api/Pessoa/setPessoa  
> POST /api/Pessoa/getbyseq  

## Mundipagg.Web

- URL: http://localhost:3000

#### Tecnologias

> AngularJS v1.6.4  
> UI.Router v0.4.2  
> ngProgressLite v1.0.8 - [URL](https://github.com/voronianski/ngprogress-lite/)  
> Angular Toastr - [URL](https://github.com/Foxandxss/angular-toastr)  
> Boostrap Framework  
> HTML5, CSS3, Javascript  



## Observações

- Tenha certeza que o projeto .API está rodando em http://localhost:2017
- Tenha certeza que o projeto .API esteja gerando o arquivo XML Documentation \bin\Mundipagg.API.xml
- Tenha certeza que o projeto .WEB está rodando em http://localhost:3000

- Ao rodar a Solution, .API abrirá uma Help Page falando sobre os endpoints da web api; .WEB abrirá a página da interface da aplicação.
