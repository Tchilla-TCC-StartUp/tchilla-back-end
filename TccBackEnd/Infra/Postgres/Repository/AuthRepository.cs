using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using NpgsqlTypes;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Auth.Dtos;
using TccBackEnd.UseCases.Usuario.Dtos;
using Bcrypt = BCrypt.Net.BCrypt;

namespace TccBackEnd.Infra.Postgres.Repository;

public class AuthRepository : IAuthRepository
{
  private readonly string _connectionString;
  public AuthRepository(string connectionString)
  {
    _connectionString = connectionString;
  }
  private string gerarTokenUsuario(Usuario usuario)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tchilla".PadRight(128)));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      issuer: "Tchilla",
      audience: "Tchilla",
      claims: new List<Claim>{
        new Claim("id", usuario.Id.ToString()),
        new Claim("nome", usuario.Nome)
      },
      expires: DateTime.Now.AddMonths(6),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
  public async Task<Result<string>> CadastrarUsuario(Usuario usuario)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "INSERT INTO usuario(NOME, TELEFONE, EMAIL, FOTO, SENHA_HASH, TIPO) VALUES(@nome, @telefone, @email, @foto, @senha, @tipo)";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@nome", usuario.Nome);
          command.Parameters.AddWithValue("@telefone", usuario.Telefone);
          command.Parameters.AddWithValue("@email", usuario.Email);
          command.Parameters.AddWithValue("@foto", "/Resources/images/user.svg");
          command.Parameters.AddWithValue("@senha", Bcrypt.HashPassword(usuario.SenhaHash));
          command.Parameters.AddWithValue("@tipo", usuario.Tipo.ToString());
          await command.ExecuteNonQueryAsync();
        }
      }

      return Result<string>.Success($"Cadastrada usuario com sucesso: {usuario.Nome}");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Cadastrar usuario: {e.Message}");
    }


  }


  public async Task<Result<string>> Logar(LogarCredenciaisDto dto)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT ID, NOME, EMAIL, TELEFONE, SENHA_HASH, TIPO FROM usuario WHERE EMAIL = @email OR NOME = @nome";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@email", dto.EmailOrUsername);
          command.Parameters.AddWithValue("@nome", dto.EmailOrUsername);
          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync())
            {
              if (Bcrypt.Verify(dto.Password, reader.GetString(4)))
              {
                Usuario usuario = new Usuario()
                {
                  Id = reader.GetInt32(0),
                  Nome = reader.GetString(1),
                  Email = reader.GetString(2),
                  Telefone = reader.GetString(3),
                  SenhaHash = reader.GetString(4),
                  // Tipo = reader.Get(5)
                };

                reader.Close();

                var updateQuery = "UPDATE usuario SET LOGADO=TRUE WHERE ID=@id";
                using (var updateCommand = new NpgsqlCommand(updateQuery, connection))
                {
                  updateCommand.Parameters.AddWithValue("@id", usuario.Id);
                  await updateCommand.ExecuteNonQueryAsync();
                }

                return Result<string>.Success(gerarTokenUsuario(usuario), "Logado usuario com sucesso");
              }
            }
          }
        }
      }

      return Result<string>.Error("Credenciais inválidas.");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Logar usuario: {e.Message}");
    }
  }


  public async Task<Result<string>> LogOut(long id)
  {
    try
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        await connection.OpenAsync();
        var query = "SELECT NOME FROM usuario WHERE ID = @id";
        using (var command = new NpgsqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@id", id);

          using (var reader = await command.ExecuteReaderAsync())
          {
            if (await reader.ReadAsync() && reader.HasRows)
            {
              query = "INSERT INTO usuario(LOGADO) VALUES(FALSE) WHERE ID=@id";

              command.Parameters.AddWithValue("@id", id);
              await command.ExecuteNonQueryAsync();

              return Result<string>.Success("LogOut usuario com sucesso");
            }
          }
        }

      }
      return Result<string>.Success($"LogOut usuario com sucesso");
    }
    catch (Exception e)
    {
      return Result<string>.Error($"Erro ao Logar usuario: {e.Message}");
    }
  }

  public Task<Result<string>> ForgotPassword(string email)
  {
    throw new NotImplementedException();
  }

  public Task<Result<string>> VerificarEmail(string token)
  {
    throw new NotImplementedException();
  }
}