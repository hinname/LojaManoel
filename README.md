## LojaManoel WEBAPI
Desafio para L2Code
### Como rodar a aplicação?
necessário ter docker instalado na máquina.
#### DATABASE
É necessário começar pela instalação do sql server para que seja criado o banco de dados utilizado pela API.
Para rodar o sql server basta rodar o seguinte comando no terminal dentro da pasta do projeto:
```
docker compose up db -d
```
Após isso usar o comando dentro do container que irá criar o database utilizado na aplicação .NET
```
docker exec -it sql_server bash
/opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'StrongPassword123' -C -Q "CREATE DATABASE lojamanoeldb"
```
#### WEB API
Após a criação do database, basta subir o container da Web API .NET, rodando o seguinte comando de terminal dentro da pasta do projeto:
```
docker compose up webapi -d
```
Só acessar o swagger na porta 8080 e testar a aplicação :D
