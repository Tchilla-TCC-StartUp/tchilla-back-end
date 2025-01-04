using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Infra.Postgres.Repository;
using TccBackEnd.Service;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;
using TccBackEnd.UseCases.Cliente.Atualizar;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.ObterPorId;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;

var builder = WebApplication.CreateBuilder(args);

// Reposistories and Use Cases configuration
builder.Services.AddScoped<IAgenciaEventosRepository>(provider => new AgenciaEventosRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AgenciaEventosService>();
builder.Services.AddScoped<CadastrarAgenciaEventosUseCase>();
builder.Services.AddScoped<AtualizarAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterPorIdAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasAgenciaEventosUseCase>();
builder.Services.AddScoped<ObterTodasPorPesquisaAgenciaEventosUseCase>();

builder.Services.AddScoped<IClienteRepository>(provider => new ClienteRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CadastrarClienteUseCase>();
builder.Services.AddScoped<AtualizarClienteUseCase>();
builder.Services.AddScoped<ObterPorIdClienteUseCase>();

builder.Services.AddScoped<IPrestadorServicoRepository>(provider => new PrestadorServicoRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CadastrarPrestadorServicoUseCase>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
