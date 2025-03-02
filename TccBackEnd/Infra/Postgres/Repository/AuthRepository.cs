using System.Data;
using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Infra.Postgres.Repository;

public class AuthRepository : IAuthRepository
{
  private readonly string _connectionString;
  public AuthRepository(string connectionString)
  {
    _connectionString = connectionString;
  }
  private string gerarTokenCliente(Cliente cliente)
  {
    return "";
  }
  public async Task<Result<string>> CadastrarCliente(Cliente cliente)
  {
    try
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
          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Cadastrada AgenciaEventos com sucesso: {cliente.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar AgenciaEventos: {e.Message}");
    }


  }

  public Task<Result<string>> ForgotPassword()
  {
    throw new NotImplementedException();
  }

  public async Task<Result<string>> LogarCliente(LogarClienteDto dto)
  {
    bool IsAutenticated = false;
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT ID,PASSWORD FROM CLIENTE WHERE EMAIL = @email or NOME = @nome";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@email", dto.EmailOrUsername);
          command.Parameters.AddWithValue("@nome", dto.EmailOrUsername);

          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              if(BCrypt.Net.BCrypt.Verify(dto.Password, reader.GetString(1)))
              {
                query = "INSERT INTO CLIENTE(ATIVO) VALUES(TRUE) WHERE ID=@id";

                command.Parameters.AddWithValue("@id", reader.GetInt64(0));
                await command.ExecuteNonQueryAsync();
                Cliente cliente = new Cliente()
                {

                };
                
                return Result<string>.Success(gerarTokenCliente(cliente), "Logado Cliente com sucesso");
              }
                

            }
          }
      
        }
      }

      return Result<string>.Success($"Cadastrada AgenciaEventos com sucesso: {dto.EmailOrUsername}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar AgenciaEventos: {e.Message}");
    }
  }

  public Task<Result<string>> LogOutCliente()
  {
    throw new NotImplementedException();
  }

  public Task<Result<string>> VerificarEmail()
  {
    throw new NotImplementedException();
  }
}