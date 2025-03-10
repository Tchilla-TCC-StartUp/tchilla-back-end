using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Infra.Postgres.Repository;
using TccBackEnd.Service;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;
using TccBackEnd.UseCases.Auth.LogOut;
using TccBackEnd.UseCases.Cliente.Atualizar;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.ObterPorId;
using TccBackEnd.UseCases.Cliente.ObterTodos;
using TccBackEnd.UseCases.Cliente.ObterTodosPorPesquisa;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "TccBackend", Version = "v1"});

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
builder.Services.AddScoped<IAgenciaEventosRepository>(provider => new AgenciaEventosRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AgenciaEventosService>();
builder.Services.AddScoped<AtualizarAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterPorIdAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasPorPesquisaAgenciaEventosUseCase>();

builder.Services.AddScoped<IClienteRepository>(provider => new ClienteRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<AtualizarClienteUseCase>();
builder.Services.AddScoped<ObterPorIdClienteUseCase>();
builder.Services.AddScoped<ObterTodosClienteUseCase>();
builder.Services.AddScoped<ObterTodosPorPesquisaClienteUseCase>();

builder.Services.AddScoped<IPrestadorServicoRepository>(provider => new PrestadorServicoRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CadastrarPrestadorServicoUseCase>();

builder.Services.AddScoped<IAuthRepository>(provider => new AuthRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CadastrarClienteUseCase>();
builder.Services.AddScoped<CadastrarAgenciaUseCase>();
builder.Services.AddScoped<LogarClienteUseCase>();
builder.Services.AddScoped<LogOutClienteUseCase>();
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
