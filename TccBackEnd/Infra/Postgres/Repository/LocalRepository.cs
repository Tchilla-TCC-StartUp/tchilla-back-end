using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Infra.Postgres.Repository;

public class LocalRepository : ILocalRepository
{
    private readonly string _connectionString;
    public LocalRepository(string connectionString)
    {
        _connectionString = connectionString;
    }


    public Task<List<Local>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Local> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<string>> Create(Local local)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();  
                var query = "Insert into local nome, descricacao, capacidade VALUES (@nome, @descricao, @capacidade)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", local.Nome);   
                    command.Parameters.AddWithValue("@descricao", local.Descricao);
                    command.Parameters.AddWithValue("@capacidade", local.Capacidade);
                    await command.ExecuteNonQueryAsync();
                }
                
            }

            return Result<string>.Success("Sucesso ao criar local");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Errro ao criar local {e.Message}");
        }
    }

    public Task<Local> Update(Local local)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<string>> Delete(int id)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();  
                var query = "Delete from local where id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id); 
                    await command.ExecuteNonQueryAsync();
                }
                
            }

            return Result<string>.Success("Sucesso ao eliminar local");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Errro ao eliminar local {e.Message}");
        }
    }
}