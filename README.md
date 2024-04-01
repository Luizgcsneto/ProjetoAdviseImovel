CRUD: .NET CORE 6 com para fins de realização do desafio proposto pela empresa Advise, realiazado com o desenvolvimento de uma aplicação de cadastro de imoveis, proprietários, corretores e inquilinos.

Recursos Utilizados no Desenvolvimento: Visual Studio 2022; NET CORE 6.0; C#; Entity Framework Core (Code First); SQL Server;

Executando Localmente: Se faz necessário executar os seguintes comandos (Package Manager Console): no Projeto de Api.Infrastructure.

(Deixar todos na versão 6.0.28)
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design 

No anquivo appsettings.json no Projeto Api.Imovel: atualizar na ConnectionStrings o seu servidor e o banco locais. 
no arquivo Program.cs no Projeto Api.Imovel atualizar também a congiruação do servidor. 
ir no menu Tools -> Nuget Packge Manager -> Packge Manager Console em Default Project colocar no arquivo de infra\Api.Infrastructure 
Executar o comando Add-Migration NomeDaMigration -Context AppDbContext e verificando se deu tudo certo.
Executar o comando  Update-Database -Context AppDbContext.
depois disso setar o projeto de Api.Imovel para inicializar o projeto.
