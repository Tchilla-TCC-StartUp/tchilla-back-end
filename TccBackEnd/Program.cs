using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Infra.Postgres.Repository;
using TccBackEnd.Service;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;
using TccBackEnd.UseCases.Auth.LogOut;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using TccBackEnd.UseCases.Usuario.Cadastrar;
using TccBackEnd.UseCases.Auth.Logar;
using TccBackEnd.UseCases.Usuario.Atualizar;
using TccBackEnd.UseCases.Usuario.ObterTodosPorPesquisa;
using TccBackEnd.UseCases.Usuario.ObterTodos;
using TccBackEnd.UseCases.Usuario.ObterPorId;
using Npgsql;
using TccBackEnd.Domain.Enums;
using TccBackEnd.UseCases.Usuario.Deletar;

var builder = WebApplication.CreateBuilder(args);

// Autentication Configuration
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Tchilla",
            ValidAudience = "Tchilla",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tchilla".PadRight(128)))
        };
    });
// Adding Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "TccBackend", Version = "v1", Description = "Tchilla é uma plataforma digital que conecta Clientes a Locais, Serviços e ou Produtos de Prestadores de Serviços e Agências de Eventos."});

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT no campo abaixo: Bearer {seu_token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
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
            new string[] { }
        }
    });
});

// Reposistories and Use Cases configuration
// builder.Services.AddScoped<IAgenciaEventosRepository>(provider => new AgenciaEventosRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AgenciaEventosService>();
// builder.Services.AddScoped<AtualizarAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterPorIdAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasPorPesquisaAgenciaEventosUseCase>();

builder.Services.AddScoped<IUsuarioRepository>(provider => new UsuarioRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CadastrarUsuarioUseCase>();
builder.Services.AddScoped<AtualizarUsuarioUseCase>();
builder.Services.AddScoped<ObterPorIdUsuarioUseCase>();
builder.Services.AddScoped<ObterTodosUsuarioUseCase>();
builder.Services.AddScoped<ObterTodosPorPesquisaUsuarioUseCase>();
builder.Services.AddScoped<DeletarUsuarioUseCase>();

// builder.Services.AddScoped<IPrestadorServicoRepository>(provider => new PrestadorServicoRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddScoped<CadastrarPrestadorServicoUseCase>();
NpgsqlConnection.GlobalTypeMapper.MapEnum<UsuarioTipo>("usuario_tipo");

builder.Services.AddScoped<IAuthRepository>(provider => new AuthRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CadastrarUsuarioUseCase>();
builder.Services.AddScoped<CadastrarUsuarioUseCase>();
builder.Services.AddScoped<LogarUseCase>();
builder.Services.AddScoped<LogOutUseCase>();

builder.Services.AddScoped<ISearchRepository>(provider => new SearchRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SearchService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
