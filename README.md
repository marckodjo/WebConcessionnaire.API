# WebConcessionnaire.API

Dans ton .csproj ou via terminal :
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools


Ajout de migration
Add-Migration NomdelaMigration -OutputDir Data/Migrations


MAJ BD
Update-Database