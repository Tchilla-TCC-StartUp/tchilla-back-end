using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
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
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tchilla".PadRight(128)));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      issuer: "Tchilla",
      audience: "Tchilla",
      claims: new List<Claim>{
        new Claim("id", cliente.Id.ToString()),
        new Claim("nome", cliente.Nome)
      },
      expires: DateTime.Now.AddMonths(6),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
  public async Task<Result<string>> CadastrarCliente(Cliente cliente)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "INSERT INTO CLIENTE(NOME, TELEFONE, EMAIL, SENHA) VALUES(@nome, @nif, @telefone, @email, @senha)";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", cliente.Nome);
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
        var query = "SELECT ID, NOME, EMAIL, TELEFONE, SENHA FROM CLIENTE WHERE EMAIL = @email OR NOME = @nome";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@email", dto.EmailOrUsername);
          command.Parameters.AddWithValue("@nome", dto.EmailOrUsername);

          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              if (Bcrypt.Verify(dto.Password, reader.GetString(5)))
              {
                long clienteId = reader.GetInt64(0);
                Cliente cliente = new Cliente()
                {
                  Id = clienteId,
                  Nome = reader.GetString(1),
                  Email = reader.GetString(2),
                  Telefone = reader.GetString(3),
                  Senha = reader.GetString(4)
                };

                reader.Close();

                var updateQuery = "UPDATE CLIENTE SET LOGADO=TRUE WHERE ID=@id";
                using (var updateCommand = new NpgsqlCommand(updateQuery, connection))
                {
                  updateCommand.Parameters.AddWithValue("@id", clienteId);
                  await updateCommand.ExecuteNonQueryAsync();
                }

                return Result<string>.Success(gerarTokenCliente(cliente), "Logado Cliente com sucesso");
              }
            }
          }
        }
      }

      return Result<string>.Error("Credenciais inválidas.");
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