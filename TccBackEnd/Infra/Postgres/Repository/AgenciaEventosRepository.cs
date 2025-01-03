using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Infra.Postgres.Repository;

public class AgenciaEventosRepository : IAgenciaEventosRepository
{
    private readonly string _connectionString;
    public AgenciaEventosRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<Result<int>> CadastrarAgenciaEventos(AgenciaEventos agencia)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO AGENCIAEVENTOS(nome, nif) VALUES (@nome, @nif)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nome", agencia.Nome);
                command.Parameters.AddWithValue("@nif", agencia.Nif);
                return (int)await command.ExecuteScalarAsync();
            }
        }
    }

    public async Task<bool> AtualizarAgenciaEventos(AgenciaEventos agencia)
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

                var rowsAffected = await command.ExecuteNonQueryAsync();
                return  rowsAffected > 0;
            }
        }
    }

    public async Task<AgenciaEventos?> ObterAgenciaEventosPorId(long id)
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
                        return new AgenciaEventos
                        {
                            Id = reader.GetInt64(0) ,
                            Nome = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
    
    

}