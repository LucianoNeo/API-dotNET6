# CONEXÃO COM BANCO DE DADOS MYSQL:

- TOOLS / NUGET PACKAGE MANAGER
- ENTITY FRAMEWORK
- ENTITY FRAMEWORK TOOLS
- POMELO MYSQL

# APPSETTINGS.JSON

```
"ConnectionStrings": {
    "FilmeConnection": "server=localhost;database=filme;user=root;password=senha"
  }
```

# CRIAR CONTEXTO

- CRIAR PASTA DATA
- CRIAR CLASSE

```
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
}
```

## PROGRAM.CS

ADICIONAR

```
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(opts =>
opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
```

# CRIAR MIGRATION DO BANCO

- TOOLS / NUGET PACKAGE MANAGER / CONSOLE

COMANDO:

```
ADD-MIGRATION CRIANDOTABELA
```

## GERAR/ATUALIZAR BANCO

```
UPDATE-DATABASE
```

# AUTOMAPPER para mapear DTOS

- TOOLS / NUGET PACKAGE MANAGER
- AUTOMAPPER
- AUTOMAPPER EXTENSIONS DEPENDENCIES INJECTION

## Adicionar ao program.cs

```
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```

## Criar pasta PROFILES

- classe FilmeProfile

```
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
    }
}
```
