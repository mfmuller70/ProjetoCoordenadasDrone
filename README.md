# Api - Autenticação

<img src="https://image.flaticon.com/icons/svg/1995/1995670.svg" height="120px">

## Dependências

- Sub Módulo shared_lib
- Instalação do Sql server 2012+ (configurar no arquivo appsettings.[ambiente].json)
- Dotnet 3.1+

## Migrações da Base de Dados

Para gerar novas migrações execute o seguinte comando

- No console: `dotnet-ef migrations add [nome_da_migracao] --context  NectonAuthenticationContext --startup-project Authentication.Api  --project Authentication.Data --output-dir Migrations`

- Ou package manager do visual studio: `Add-Migration [nome_da_migracao] -Context NectonAuthenticationContext -StartupProject Authentication.Api -Project Authentication.Data -OutputDir Migrations`
