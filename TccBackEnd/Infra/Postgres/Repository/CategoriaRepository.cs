using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

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

  public async Task<Result<string>> AtualizarCategoria(Categoria categoria)
  {
    try
    {
      using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync(); 
        var query = "update categoria set nome=@Nome, descricao=@Descricao where id = @Id";
        
        using (var command = new Npgsql.NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@Id", categoria.Id);
          command.Parameters.AddWithValue("@Nome", categoria.Nome);
          command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

          int rowsAffected = await command.ExecuteNonQueryAsync();
          
          if (rowsAffected > 0)
            return Result<string>.Success("Categoria atualizado com sucesso");
          else
            return Result<string>.Error("Erro ao atualizar categoria");
        }

      }
    }
    catch (Exception ex)
    {
      return Result<string>.Error("Erro ao atualizar categoria");
    }
  }

  public async Task<Result<string>> RemoverCategoria(int id)
  {
    try
    {
      using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync(); 
        var query = "Delete from categoria where id = @Id";
        
        using (var command = new Npgsql.NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@Id", id);

          int rowsAffected = await command.ExecuteNonQueryAsync();
          
          if (rowsAffected > 0)
            return Result<string>.Success("Categoria removida com sucesso");
          else
            return Result<string>.Error("Erro ao removida categoria");
        }

      }
    }
    catch (Exception ex)
    {
      return Result<string>.Error("Erro ao removida categoria");
    }
  }

  public async Task<Result<List<CategoriaOutPutDto>>> ObterTodasCategorias()
  {
    List<CategoriaOutPutDto> categorias = new List<CategoriaOutPutDto>();
    try
    {
      using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync(); 
        var query = "select * from categoria";
        
        using (var command = new Npgsql.NpgsqlCommand(query, connection))
        {
          using (var reader = await command.ExecuteReaderAsync())
          {
            while (await reader.ReadAsync() && reader.HasRows)
            {
              categorias.Add(
                new CategoriaOutPutDto
                {
                  Id = reader.GetInt32(0),
                  Nome = reader.GetString(1),
                  Descricao = reader.GetString(2)
                }
              );
            }
            return Result<List<CategoriaOutPutDto>>.Success(categorias, "Categorias obtidas com sucesso");
          }
          
        }

      }
    }
    catch (Exception ex)
    {
      return Result<List<CategoriaOutPutDto>>.Error($"Erro ao carregar categorias");
    }
  }
}
