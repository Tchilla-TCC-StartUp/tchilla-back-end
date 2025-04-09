using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Infra.Postgres.Repository;

public class CategoriaRepository : ICategoriaRepository
{
  private string _connectionString;
  public CategoriaRepository(string connectionString)
  {
    _connectionString = connectionString;
  }
  public async Task<Result<string>> CriarCategoria(Categoria categoria)
  {
    try
    {
      using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync(); 
        var query = "INSERT INTO categoria (nome, descricao) VALUES (@Nome, @Descricao)";
        
        using (var command = new Npgsql.NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@Nome", categoria.Nome);
          command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

          int rowsAffected = await command.ExecuteNonQueryAsync();
          
          if (rowsAffected > 0)
            return Result<string>.Success("Categoria criada com sucesso");
          else
            return Result<string>.Error("Erro ao criar categoria");
        }

      }
    }
    catch (Exception ex)
    {
      return Result<string>.Error("Erro ao criar categoria: " + ex.Message);
    }
  }

  public Task<Result<string>> AtualizarCategoria(Categoria categoria)
  {
    throw new NotImplementedException();
  }

  public Task<Result<string>> RemoverCategoria(Categoria categoria)
  {
    throw new NotImplementedException();
  }

  public Task<Result<string>> ObterTodasCategorias(Categoria categoria)
  {
    throw new NotImplementedException();
  }
}
