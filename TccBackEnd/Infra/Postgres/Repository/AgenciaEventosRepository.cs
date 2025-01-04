using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Infra.Postgres.Repository;

public class AgenciaEventosRepository : IAgenciaEventosRepository
{
    private readonly string _connectionString;
    public AgenciaEventosRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<Result<string>> CadastrarAgenciaEventos(AgenciaEventos agencia)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "Insert INTO AGENCIAEVENTOS(nome, nif) VALUES (@nome, @nif)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", agencia.Nome);
                    command.Parameters.AddWithValue("@nif", agencia.Nif);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success($"Cadastrada AgenciaEventos com sucesso: {agencia.Nome}");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar AgenciaEventos: {e.Message}");
        }
        
    }

    public async Task<Result<string>> AtualizarAgenciaEventos(AgenciaEventos agencia)
    {
        try
        {
            using (var connection = new NpgsqlConnection())
            {
                await connection.OpenAsync();
                var query = "UPDATE AGENCIAEVENTOS SET NOME=@nome, NIF=@nif WHERE id=@id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", agencia.Nome);
                    command.Parameters.AddWithValue("@nif", agencia.Nif);
                    command.Parameters.AddWithValue("@id", agencia.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
            
            return Result<string>.Success($"Atualizada AgenciaEventos com sucesso: {agencia.Nome}");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar AgenciaEventos: {e.Message}");
        }
        
    }

    public async Task<Result<AgenciaEventosOutputDto?>> ObterAgenciaEventosPorId(long id)
    {
        AgenciaEventosOutputDto? agenciaEventosOutputDto = new AgenciaEventosOutputDto();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM AGENCIAEVENTOS WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            agenciaEventosOutputDto = new AgenciaEventosOutputDto()
                            {
                                Id = reader.GetInt64(0) ,
                                Nome = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            
            return Result<AgenciaEventosOutputDto>.Success(agenciaEventosOutputDto, "Obtida Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<AgenciaEventosOutputDto>.Error($"Erro ao obter AgenciaEventos: {e.Message}");
        }
    }

    public async Task<Result<List<AgenciaEventosOutputDto>?>> ObterTodasAgenciasEventos()
    {
        List<AgenciaEventosOutputDto>? agenciasEventosOutputDtos = new List<AgenciaEventosOutputDto>();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM AGENCIAEVENTOS;";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            agenciasEventosOutputDtos = new List<AgenciaEventosOutputDto>()
                            {
                                new AgenciaEventosOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    DataNascimento = reader.GetDateTime(5),
                                    Avatar = reader.GetString(6)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<AgenciaEventosOutputDto>>.Success(agenciasEventosOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<AgenciaEventosOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }

    }

    public async Task<Result<List<AgenciaEventosOutputDto>?>> ObterTodasAgenciasEventosPorPesquisa(string consulta)
    {
        List<AgenciaEventosOutputDto>? agenciasEventosOutputDtos = new List<AgenciaEventosOutputDto>();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM AGENCIAEVENTOS;";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            agenciasEventosOutputDtos = new List<AgenciaEventosOutputDto>()
                            {
                                new AgenciaEventosOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    DataNascimento = reader.GetDateTime(5),
                                    Avatar = reader.GetString(6)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<AgenciaEventosOutputDto>>.Success(agenciasEventosOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<AgenciaEventosOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }
    }
}