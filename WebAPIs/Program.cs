using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfacesServices;
using Domain.InterfacesExternal;
using Domain.Services;
using Entities.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Infrastructure.Repository.RepositoryExternal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebAPIs.FluentValidations;
using WebAPIs.Models;
using WebAPIs.ProgramConfigs;
using WebAPIs.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services FluentValidation
builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

// ConfigServices ConnectionString
builder.Services.AddDbContext<ContextBase>(options => options
                .UseSqlite(builder.Configuration
                .GetConnectionString("DefaultConnection"))
);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options
                .SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Interface e Repositorio
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IMessage, RepositoryMessage>();
builder.Services.AddSingleton<IPokemonsCapturados, RepositoryPokemonsCapturados>();
builder.Services.AddSingleton<IPokemon, RepositoryPokemon>();

// Servico Dominio
builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();
builder.Services.AddSingleton<IServicePokemonsCapturados, ServicePokemonsCapturados>();
builder.Services.AddSingleton<IServicePokemonsCapturados, ServicePokemonsCapturados>();

//JWT Tokens
builder.Services.AddAuthentication(JWTConfig.GetJWTConfig()).AddJwtBearer(JWTConfig.AddJwtBearerConfig(builder));

// Mapper
var config = new MapperConfiguration( cfg =>
{
    cfg.CreateMap<MessageViewModel, Message>();
    cfg.CreateMap<Message, MessageViewModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerConfig.SwaggerOptions());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(SwaggerConfig.GetEndpoint());

 //CORs
var devClient = "http://localhost:7171";
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
