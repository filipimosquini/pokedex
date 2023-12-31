# Pokedex

O Projeto que simula uma pokedex. O projeto foi feito em duas versões: uma em .NET Framework 4.8 e a outra em .NET 6 tendo as mesmas regras de negócio mas com as diferenças de implementação de cada plataforma.

## Arquitetura

![image](https://github.com/filipimosquini/pokedex/assets/5280221/09506f72-9dfe-4180-ad77-4210413bfe88)

A arquitetura do projeto foi pensada com base na arquitetura Onion logo suas camadas são descritas abaixo:

* Backend.Api: É o entrypoint da aplicação, aonde são configurados os endpoints e as configurações de execução da aplicação.
* Backend.Application: É a camada responsável pelas implementações dos serviços da aplicação e de domínio, os validadores das requisições e as integrações com as fontes externas.
* Backend.Domain: É a camada que representa o core da aplicação, aonde estão as abstrações, modelos, mapeamentos, queries, etc. é a camada mais pura e produnda da arquitetura.
* Backend.Infra: É a camada responsável por manter as implementações e configurações de acesso ao banco de dados.
* Backend.Ioc: É a camada responsável por gerenciar as injeções de dependência do sistema.
* Backend.CrossCutting: É a camada responsável por manter as classes que podem ser usadas por quaisquer projetos do sistema.

## Execução do projeto

Para executar o projeto é requerido que se tenha o docker instalado na máquina.

![image](https://github.com/filipimosquini/pokedex/assets/5280221/a7e742d2-3e8e-4f8a-98b5-aaff95cf922c)

Abra uma janela de prompt de comando na pasta aonde está o arquivo docker_compose.yml e execute o comando abaixo:

docker-compose -f docker_compose.yml  up

Após o término da execução, acesse a URL http://localhost:5000/swagger/index.html.  

Será carregada a tela abaixo

![image](https://github.com/filipimosquini/pokedex/assets/5280221/8f6550ac-80f8-4a07-81ed-412e2634e66b)

## Ferramentas e Frameworks

* .Net Framework 4.8.1
* .Net6
* EntityFrameworkCore
* Docker
* SQLite  
