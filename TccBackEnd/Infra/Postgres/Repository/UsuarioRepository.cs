using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Usuario.Dtos;
using Bcrypt = BCrypt.Net.BCrypt;

namespace TccBackEnd.Infra.Postgres.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;
    public UsuarioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Result<string>> Atualizar(Usuario usuario)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE usuario SET nome = @nome, email = @email, telefone = @telefone WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", usuario.Nome);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@id", usuario.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Usuario Atualizado com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao atualizar usuario");
        }
    }


    public async Task<Result<string>> Cadastrar(Usuario usuario)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO usuario(nome, email, telefone, senha_hash, foto, tipo) VALUES(@nome, @email, @telefone, @senha, @foto, @tipo)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", usuario.Nome);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@senha", Bcrypt.HashPassword(usuario.SenhaHash));
                    command.Parameters.AddWithValue("@foto", usuario.Foto);
                    command.Parameters.AddWithValue("@tipo", usuario.Tipo.ToString());
                    using(var reader = await command.ExecuteReaderAsync())
          {
            if(await reader.ReadAsync())
            {
              return Result<string>.Success(reader.GetString(0),$"Cadastrada um,suario com sucesso: {usuario.Nome}");
            }
          }
                }
            }

            return Result<string>.Success($"Cadastrado Usuario com sucesso: {usuario.Nome}");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar Usuario" + e.ToString());
        }
    }

    public async Task<Result<UsuarioOutputDto?>> ObterPorId(int id)
    {
        UsuarioOutputDto? usuarioOutputDto = new UsuarioOutputDto();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT id, nome, email, telefone, foto FROM usuario WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuarioOutputDto = new UsuarioOutputDto()
                            {
                                Id = reader.GetInt64(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefone = reader.GetString(3),
                                Foto = reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return Result<UsuarioOutputDto>.Success(usuarioOutputDto, "Obtido usuario com sucesso");
        }
        catch (Exception e)
        {
            return Result<UsuarioOutputDto>.Error($"Erro ao obter usuario");
        }

        }



    public async Task<Result<List<UsuarioOutputDto>?>> ObterTodos()
    {
        List<UsuarioOutputDto>? usuariosOutputDtos = new List<UsuarioOutputDto>();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT id, nome, email, telefone, foto FROM usuario;";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync() && reader.HasRows)
                        {
                            usuariosOutputDtos.Add(new UsuarioOutputDto()
                            {
                                Id = reader.GetInt64(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefone = reader.GetString(3),
                                Foto = reader.GetString(4)
                            });
                        }
                        
                    }
                }
            }

            return Result<List<UsuarioOutputDto>>.Success(usuariosOutputDtos, "Obtidas todas usuarios de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<UsuarioOutputDto>>.Error($"Erro ao obter Agencias de Eventos");
        }
    }

    public async Task<Result<List<UsuarioOutputDto>?>> ObterTodosusuariosPorPesquisa(string consulta)
    {
        List<UsuarioOutputDto>? usuariosOutputDtos = new List<UsuarioOutputDto>();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM AGENCIAEVENTOS;";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuariosOutputDtos = new List<UsuarioOutputDto>()
                            {
                                new UsuarioOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    Foto = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }

            return Result<List<UsuarioOutputDto>>.Success(usuariosOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<UsuarioOutputDto>>.Error($"Erro ao obter Agencias de Eventos");
        }
    }

    public Task<Result<List<UsuarioOutputDto>?>> ObterTodosPorPesquisa(string consulta)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<string>> DeletarUsuario(int idUsuario)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "Delete from usuario where id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idUsuario);

                    var rowsAffected = await  command.ExecuteNonQueryAsync();

                    if(rowsAffected == null)
                    {
                        return Result<string>.Error($"Usuario não encontrado");
                    }
                    if (rowsAffected > 0)
                        return Result<string>.Success($"Removido usuario com sucesso");
                    else    
                        return Result<string>.Error($"Erro ao remover usuario");

                }
            }

           
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar Usuario");
        }
    }


}