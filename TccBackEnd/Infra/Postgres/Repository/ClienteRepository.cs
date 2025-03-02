using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Infra.Postgres.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;
    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Result<string>> AtualizarCliente(Cliente cliente)
    {
        try
        {
            using (var connection = new NpgsqlConnection( _connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE CLIENTE SET nome = @nome, telefone = @telefone WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@id", cliente.Id);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Cliente Atualizado com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao atualizar Cliente: {e.Message}");
        }
    }

    public async Task<Result<ClienteOutputDto>> ObterClientePorId(long id)
    {
        ClienteOutputDto? clienteOutputDto = new ClienteOutputDto();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM CLIENTE WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            clienteOutputDto = new ClienteOutputDto()
                            {
                                Id = reader.GetInt64(0),
                                Nome = reader.GetString(1),
                                Nif = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return Result<ClienteOutputDto>.Success(clienteOutputDto, "Obtido Cliente com sucesso");
        }
        catch (Exception e)
        {
            return Result<ClienteOutputDto>.Error($"Erro ao obter Cliente: {e.Message}");
        }
        
    }

    public async Task<Result<List<ClienteOutputDto>?>> ObterTodosClientes()
    {
        List<ClienteOutputDto>? clientesOutputDtos = new List<ClienteOutputDto>();
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
                            clientesOutputDtos = new List<ClienteOutputDto>()
                            {
                                new ClienteOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    Avatar = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<ClienteOutputDto>>.Success(clientesOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<ClienteOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }
    }

    public async Task<Result<List<ClienteOutputDto>?>> ObterTodosClientesPorPesquisa(string consulta)
    {
        List<ClienteOutputDto>? clientesOutputDtos = new List<ClienteOutputDto>();
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
                            clientesOutputDtos = new List<ClienteOutputDto>()
                            {
                                new ClienteOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    Avatar = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<ClienteOutputDto>>.Success(clientesOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<ClienteOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }
    }
}