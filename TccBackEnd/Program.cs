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
using TccBackEnd.UseCases.Auth.ChangePassword;
using TccBackEnd.UseCases.Cadastrar.Local;
using TccBackEnd.UseCases.Categoria.Cadastrar;
using TccBackEnd.UseCases.Endereco.Cadastrar;
using TccBackEnd.UseCases.Local.Atualizar;
using TccBackEnd.UseCases.Local.ObterPorId;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;
using TccBackEnd.UseCases.Search;
using TccBackEnd.UseCases.Usuario.Deletar;
using TccBackEnd.UseCases.Categoria.Remover;
using TccBackEnd.UseCases.SubCategoria.Cadastrar;
using TccBackEnd.UseCases.SubCategoria.ObterTodas;
using TccBackEnd.UseCases.SubCategoria.Remover;

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
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "TccBackend",
            Version = "v1",
            Description = "Tchilla é uma plataforma digital que conecta Clientes a Locais, Serviços e ou Produtos de Prestadores de Serviços e Agências de Eventos."
        });

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

builder.Services.AddScoped<IPrestadorRepository>(provider => new PrestadorServicoRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthRepository>(provider => new AuthRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CadastrarPrestadorUseCase>();
builder.Services.AddScoped<CadastrarUsuarioUseCase>();
builder.Services.AddScoped<LogarUseCase>();
builder.Services.AddScoped<ChangePasswordUseCase>();
builder.Services.AddScoped<LogOutUseCase>();

builder.Services.AddScoped<ISearchRepository>(provider => new SearchRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<SearchLocalUseCase>();

builder.Services.AddScoped<IEnderecoRepository>(provider =>
    new EnderecoRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<CadastrarEnderecoUseCase>();
builder.Services.AddScoped<CadastrarPaisUseCase>();
builder.Services.AddScoped<CadastrarProvinciaUseCase>();


builder.Services.AddScoped<ILocalRepository>(provider =>
    new LocalRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<LocalService>();
builder.Services.AddScoped<CadastrarLocalUseCase>();
builder.Services.AddScoped<AtualizarLocalUseCase>();
builder.Services.AddScoped<ObterPorIdLocalUseCase>();


builder.Services.AddScoped<ICategoriaRepository>(provider =>
    new CategoriaRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<CadastrarCategoriaUseCase>();
builder.Services.AddScoped<AtualizarCategoriaUseCase>();
builder.Services.AddScoped<ObterTodasCategoriaUseCase>();   
builder.Services.AddScoped<RemoverCategoriaUseCase>();

builder.Services.AddScoped<ISubCategoriaRepository>(provider =>
    new SubCategoriaRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SubCategoriaService>();
builder.Services.AddScoped<CadastrarSubCategoriaUseCase>();
builder.Services.AddScoped<AtualizarSubCategoriaUseCase>();
builder.Services.AddScoped<ObterTodasSubCategoriaUseCase>();   
builder.Services.AddScoped<RemoverSubCategoriaUseCase>();
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

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
