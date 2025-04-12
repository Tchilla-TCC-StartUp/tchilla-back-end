using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.Infra.Postgres.Repository;

public class ServicoRepository : IServicoRepository
{
  private readonly string _connectionString;
  public ServicoRepository(string connectionString)
  {
    _connectionString = connectionString;
  }
  public async Task<Result<string>> CriarServicoAgencia(ServicoAgencia servico)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "Insert INTO SERVICOAGENCIA(nome, descricao, preco) VALUES (@nome, @descricao, @preco)";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", servico.Nome);
          command.Parameters.AddWithValue("@descricao", servico.Descricao);
          command.Parameters.AddWithValue("@preco", servico.Preco);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Cadastrado Servico com sucesso: {servico.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar Servico: {e.Message}");
    }
  }
  public async Task<Result<string>> CriarServicoPrestador(ServicoPrestador servico)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "Insert INTO SERVICOPRESTADOR(nome, descricao, preco) VALUES (@nome, @descricao, @preco)";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", servico.Nome);
          command.Parameters.AddWithValue("@descricao", servico.Descricao);
          command.Parameters.AddWithValue("@preco", servico.Preco);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Cadastrado Servico com sucesso: {servico.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar Servico: {e.Message}");
    }
  }
  public async Task<Result<string>> AtualizarServicoPrestador(ServicoPrestador servico)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "UPDATE SERVICOPRESTADOR SET NOME=@nome, DESCRICAO=@descricao, PRECO=@preco WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", servico.Nome);
          command.Parameters.AddWithValue("@descricao", servico.Descricao);
          command.Parameters.AddWithValue("@preco", servico.Preco);
          command.Parameters.AddWithValue("@id", servico.Id);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Atualizado Servico com sucesso: {servico.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Atualizar Servico: {e.Message}");
    }
  }
  public async Task<Result<string>> RemoverServico(int id)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "DELETE FROM SERVICOPRESTADOR WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Removido Servico com sucesso: {id}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Remover Servico: {e.Message}");
    }
  }
  public async Task<Result<List<ServicoOutPutDto>>> ObterTodosServicos()
  {
    List<ServicoOutPutDto> servicos = new List<ServicoOutPutDto>();
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT * FROM SERVICOPRESTADOR";
        using (var command = new NpgsqlCommand(query, connection))
        {
          using (var reader = await command.ExecuteReaderAsync())
          {
            while (await reader.ReadAsync())
            {
              servicos.Add(new ServicoOutPutDto
              {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.GetString(2),
                Preco = reader.GetDecimal(3)
              });
            }
          }
        }
      }

      return Result<List<ServicoOutPutDto>>.Success(servicos, "Servicos encontrados");
    }
    catch (Exception e)
    {
      return Result<List<ServicoOutPutDto>>.Error($"Erro ao Obter Servicos: {e.Message}");
    }
  }
  public async Task<Result<List<ServicoOutPutDto>>> ObterTodosServicosAgencia()
  {
    List<ServicoOutPutDto> servicos = new List<ServicoOutPutDto>();
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT * FROM SERVICOAGENCIA";
        using (var command = new NpgsqlCommand(query, connection))
        {
          using (var reader = await command.ExecuteReaderAsync())
          {
            while (await reader.ReadAsync())
            {
              servicos.Add(new ServicoOutPutDto
              {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.GetString(2),
                Preco = reader.GetDecimal(3)
              });
            }
          }
        }
      }

      return Result<List<ServicoOutPutDto>>.Success(servicos, "Servicos encontrados");
    }
    catch (Exception e)
    {
      return Result<List<ServicoOutPutDto>>.Error($"Erro ao Obter Servicos: {e.Message}");
    }
  }
  public async Task<Result<ServicoOutPutDto?>> ObterServicoPorId(int id)
  {
    ServicoOutPutDto? servico = new ServicoOutPutDto();
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT * FROM SERVICOPRESTADOR WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);
          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              servico = new ServicoOutPutDto
              {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.GetString(2),
                Preco = reader.GetDecimal(3)
              };
            }
          }
        }
      }

      return Result<ServicoOutPutDto>.Success(servico, "Servico encontrado");
    }
    catch (Exception e)
    {
      return Result<ServicoOutPutDto>.Error($"Erro ao Obter Servicos: {e.Message}");
    }
  }
  public async Task<Result<ServicoOutPutDto?>> ObterServicoAgenciaPorId(int id)
  {
    ServicoOutPutDto? servico = new ServicoOutPutDto();
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT * FROM SERVICOAGENCIA WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);
          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              servico = new ServicoOutPutDto
              {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.GetString(2),
                Preco = reader.GetDecimal(3)
              };
            }
          }
        }
      }

      return Result<ServicoOutPutDto>.Success(servico, "Servico encontrado");
    }
    catch (Exception e)
    {
      return Result<ServicoOutPutDto>.Error($"Erro ao Obter Servicos: {e.Message}");
    }
  }
  public async Task<Result<string>> RemoverServicoAgencia(int id)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "DELETE FROM SERVICOAGENCIA WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Removido Servico com sucesso: {id}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Remover Servico: {e.Message}");
    }
  }
  public async Task<Result<string>> AtualizarServicoAgencia(ServicoPrestador servico)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "UPDATE SERVICOAGENCIA SET NOME=@nome, DESCRICAO=@descricao, PRECO=@preco WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", servico.Nome);
          command.Parameters.AddWithValue("@descricao", servico.Descricao);
          command.Parameters.AddWithValue("@preco", servico.Preco);
          command.Parameters.AddWithValue("@id", servico.Id);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Atualizado Servico com sucesso: {servico.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Atualizar Servico: {e.Message}");
    }
  }
  public async Task<Result<string>> RemoverServicoPrestador(int id)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "DELETE FROM SERVICOPRESTADOR WHERE id=@id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);

          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Removido Servico com sucesso: {id}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Remover Servico: {e.Message}");
    }
  }

  Task<Result<List<ServicoOutPutDto>>> IServicoRepository.ObterTodosServicos()
  {
    throw new NotImplementedException();
  }
}