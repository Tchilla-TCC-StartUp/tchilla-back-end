using System.Data;
using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;
using Bcrypt = BCrypt.Net.BCrypt;

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
        var query = "INSERT INTO CLIENTE(NOME, NIF, TELEFONE, EMAIL, SENHA) VALUES(@nome, @nif, @telefone, @email, @senha)";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", cliente.Nome);
          command.Parameters.AddWithValue("@nif", cliente.Nome);
          command.Parameters.AddWithValue("@telefone", cliente.Telefone);
          command.Parameters.AddWithValue("@email", cliente.Email);
          command.Parameters.AddWithValue("@senha", Bcrypt.HashPassword(cliente.Senha));
          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Cadastrada Cliente com sucesso: {cliente.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar Cliente: {e.Message}");
    }


  }

  public Task<Result<string>> ForgotPassword()
  {
    throw new NotImplementedException();
  }

  public async Task<Result<string>> LogarCliente(LogarCredenciaisDto dto)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT ID, NOME, NIF, EMAIl, TELFONE, PASSWORD FROM CLIENTE WHERE EMAIL = @email or NOME = @nome";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@email", dto.EmailOrUsername);
          command.Parameters.AddWithValue("@nome", dto.EmailOrUsername);

          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              if(Bcrypt.Verify(dto.Password, reader.GetString(4)))
              {
                query = "INSERT INTO CLIENTE(LOGADO) VALUES(TRUE) WHERE ID=@id";

                command.Parameters.AddWithValue("@id", reader.GetInt64(0));
                await command.ExecuteNonQueryAsync();
                Cliente cliente = new Cliente()
                {
                  Nome = reader.GetString(0),
                  Email = reader.GetString(1),
                  Nif = reader.GetString(2),
                  Telefone = reader.GetString(3),
                  Senha = reader.GetString(4)
                };
                
                return Result<string>.Success(gerarTokenCliente(cliente), "Logado Cliente com sucesso");
              }
            }
          }
      
        }
      }

      return Result<string>.Success($"Logado Cliente com sucesso: {dto.EmailOrUsername}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Logar Cliente: {e.Message}");
    }
  }

  public async Task<Result<string>> LogOutCliente(long id)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT NOME FROM CLIENTE WHERE ID = @id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);

          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync() && reader.HasRows)
            {
              query = "INSERT INTO CLIENTE(LOGADO) VALUES(FALSE) WHERE ID=@id";

                command.Parameters.AddWithValue("@id", id);
                await command.ExecuteNonQueryAsync();
              
                return Result<string>.Success("LogOut Cliente com sucesso");
              }
            }
          }
      
        }
      return Result<string>.Success($"LogOut Cliente com sucesso");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Logar Cliente: {e.Message}");
    }
  }

  public Task<Result<string>> VerificarEmail()
  {
    throw new NotImplementedException();
  }

    public Task<Result<string>> LogarAgencia(LogarCredenciaisDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> CadastrarAgencia(Agencia agencia)
    {
        throw new NotImplementedException();
    }
}