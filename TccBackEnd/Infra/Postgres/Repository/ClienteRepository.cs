using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;

namespace TccBackEnd.Infra.Postgres.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;
    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task<int> CadastrarCliente(Cliente cliente)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO CLIENTE(NOME, NIF, TELEFONE) VALUES(@nome, @nif, @telefone)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@nif", cliente.Nome);
                command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                return (int) await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task<Cliente?> ObterClientePorId(long id)
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
                        return new Cliente
                        {
                            Id = reader.GetInt64(0),
                            Nome = reader.GetString(1),
                            Nif = reader.GetString(2),
                        };
                    }
                }

                return null;
            }
        }
    }
}