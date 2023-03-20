using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfacesServices;
using Domain.InterfacesExternal;
using Domain.Services;
using Entities.Entities;
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
using WebAPIs.Models;
using WebAPIs.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ConfigServices
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

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          var jk = JwtSecurityKey.Create("Secret_Key-12345678");

          option.TokenValidationParameters = new TokenValidationParameters
          {
              RequireAudience = false,

              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = false,
              ValidateActor = false,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Issuer.Bearer",
              ValidAudience = "Teste.Audience.Bearer",
              IssuerSigningKey = jk
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  var teste = context.Exception.Message;
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  var teste = context.SecurityToken;
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);;
                  return Task.CompletedTask;
              }
          };
      });

// Mapper
var config = new MapperConfiguration( cfg =>
{
    cfg.CreateMap<MessageViewModel, Message>();
    cfg.CreateMap<Message, MessageViewModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

///builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme." +
                "\r\n\r\n Enter 'Bearer' [Space] and then you token in the text input below." +
                "\r\n\r\n Example: Bearer 12345abcdef"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(uiOptions =>
{
    uiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1");
});
//}

// CORs
//var devClient = "http://localhost:7171";
//app.UseCors(x => x
//.AllowAnyOrigin()
//.AllowAnyMethod()
//.AllowAnyHeader()
//.WithOrigins(devClient));


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
