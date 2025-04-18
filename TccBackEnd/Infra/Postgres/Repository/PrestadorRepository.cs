using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.Infra.Postgres.Repository;

public class PrestadorServicoRepository : IPrestadorRepository
{
    private readonly string _connectionString;

    public PrestadorServicoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Result<List<PrestadorOutputDto>>> ObterTodosPrestador()
    {
        List<PrestadorOutputDto> prestadores = new();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT id, nome, email, telefone FROM prestador";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            prestadores.Add(new PrestadorOutputDto
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefone = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return Result<List<PrestadorOutputDto>>.Success(prestadores, "Prestadores encontrados");
        }
        catch (Exception e)
        {
            return Result<List<PrestadorOutputDto>>.Error($"Erro ao consultar prestadores: {e.Message}");
        }
    }

    public async Task<PrestadorOutputDto> ObterPrestadorServicoPorId(long id)
    {
        PrestadorOutputDto? prestador = null;
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM prestadorservico WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            prestador = new PrestadorOutputDto
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefone = reader.GetString(3),
                            };
                        }
                    }
                }
            }

            return prestador!;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao consultar prestador");
        }
    }
}
