using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.Util;

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
        var query = "INSERT INTO categoria (nome, descricao, foto) VALUES (@Nome, @Descricao, @Foto)";
        
        using (var command = new Npgsql.NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@Nome", categoria.Nome);
          command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
          command.Parameters.AddWithValue("@Foto", categoria.Foto);
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

            string selectQuery = "SELECT foto FROM categoria WHERE id = @Id";
            string? fotoAntiga = null;

            using (var selectCmd = new NpgsqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@Id", categoria.Id);

                using (var reader = await selectCmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        fotoAntiga = reader["foto"]?.ToString();
                }
            }

            var updateQuery = @"
                UPDATE categoria 
                SET nome = @Nome, descricao = @Descricao, foto = @Foto 
                WHERE id = @Id";

            using (var updateCmd = new NpgsqlCommand(updateQuery, connection))
            {
                updateCmd.Parameters.AddWithValue("@Id", categoria.Id);
                updateCmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                updateCmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                updateCmd.Parameters.AddWithValue("@Foto", categoria.Foto);

                int rowsAffected = await updateCmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    if (!string.IsNullOrWhiteSpace(fotoAntiga) && fotoAntiga != categoria.Foto)
                        StorageUtil.RemoveFile(fotoAntiga);

                    return Result<string>.Success("Categoria atualizada com sucesso");
                }
                else
                {
                    return Result<string>.Error("Categoria não encontrada");
                }
            }
        }
    }
    catch (Exception ex)
    {
        return Result<string>.Error($"Erro ao atualizar categoria {ex.ToString()}");
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
                  Descricao = reader.GetString(2),
                  Foto = reader.GetString(3)
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
      return Result<List<CategoriaOutPutDto>>.Error($"Erro ao carregar categorias {ex}");
    }
  }
}
