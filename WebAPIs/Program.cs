using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.InterfacesExternal;
using Domain.InterfacesExternal.InterfacesServices;
using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Domain.Services;
using Domain.ServicesExternal;
using Domain.ServicesInternal;
using Domain.Utils.InterfaceGenerics;
using Entities.Entities;
using FluentValidation.AspNetCore;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Infrastructure.Repository.RepositoriesInternal;
using Infrastructure.Repository.RepositoryExternal;
using Microsoft.EntityFrameworkCore;
using WebAPIs.Models;
using WebAPIs.ProgramConfigs;
using WebAPIs.ViewModels;

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

//AspNetCore Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

// Domain Service
builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();
builder.Services.AddSingleton<IServicePokemonsCapturados, ServicePokemonsCapturados>();
builder.Services.AddSingleton<IServicePokemon, ServicePokemon>();
builder.Services.AddSingleton<IServiceTelefone, ServiceTelefone>();
builder.Services.AddSingleton<IServiceUserEnderecos, ServiceUserEnderecos>();
builder.Services.AddSingleton<IServiceFile, ServiceFile>();

// Interface and Repository
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IMessageInfrastructure, RepositoryMessage>();
builder.Services.AddSingleton<IPokemonsCapturadosInfrastructure, RepositoryPokemonsCapturados>();
builder.Services.AddSingleton<IPokemonInfrastructure, RepositoryPokemon>();
builder.Services.AddSingleton<ITelefoneInfrasctructure, RepositoryTelefone>();
builder.Services.AddSingleton<IUserEnderecosInfrastructure, RepositoryUserEnderecos>();
builder.Services.AddSingleton<IFileInfrastructure, RepositoryFile>();

//JWT Tokens
builder.Services.AddAuthentication(JWTConfig.GetJWTConfig()).AddJwtBearer(JWTConfig.AddJwtBearerConfig(builder));

// Mapper
var config = new MapperConfiguration(mapper =>
{
    mapper.CreateMap<Message, MessageViewModel>().ReverseMap();
    mapper.CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
    mapper.CreateMap<UserEndereco, UserEnderecoViewModel>().ReverseMap();
    mapper.CreateMap<UserShawandpartners, UserShawandpartnersViewModel>().ReverseMap();
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
var devClient = "http://localhost:5000";
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