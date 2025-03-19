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
            using (var connection = new NpgsqlConnection( _connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE usuario SET nome = @nome, email = @email, telefone = @telefone WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", usuario.Nome);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@id", usuario.Id);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Usuario Atualizado com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao atualizar Cliente: {e.Message}");
        }
    }


    public async Task<Result<string>> Cadastrar(Usuario usuario)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO usuario(nome, email, telefone, tipo, senha_hash) VALUES(@nome, @email, @telefone, @tipo, @senha)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", usuario.Nome);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@tipo", usuario.Tipo);
                    command.Parameters.AddWithValue("@senha", Bcrypt.HashPassword(usuario.SenhaHash));
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success($"Cadastrado Usuario com sucesso: {usuario.Nome}");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar Usuario: {e.Message}");
        }
    }

    public async Task<Result<UsuarioOutputDto>> ObterClientePorId(long id)
    {
        UsuarioOutputDto? clienteOutputDto = new UsuarioOutputDto();
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM CLIENTE WHERE id = @id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            clienteOutputDto = new UsuarioOutputDto()
                            {
                                Id = reader.GetInt64(0),
                                Nome = reader.GetString(1),
                                Nif = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return Result<UsuarioOutputDto>.Success(clienteOutputDto, "Obtido Cliente com sucesso");
        }
        catch (Exception e)
        {
            return Result<UsuarioOutputDto>.Error($"Erro ao obter Cliente: {e.Message}");
        }
        
    }

    public Task<Result<UsuarioOutputDto?>> ObterPorId(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<UsuarioOutputDto>?>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<UsuarioOutputDto>?>> ObterTodosClientes()
    {
        List<UsuarioOutputDto>? clientesOutputDtos = new List<UsuarioOutputDto>();
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
                        while(await reader.ReadAsync())
                        {
                            clientesOutputDtos = new List<UsuarioOutputDto>()
                            {
                                new UsuarioOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    Avatar = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<UsuarioOutputDto>>.Success(clientesOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<UsuarioOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }
    }

    public async Task<Result<List<UsuarioOutputDto>?>> ObterTodosClientesPorPesquisa(string consulta)
    {
        List<UsuarioOutputDto>? clientesOutputDtos = new List<UsuarioOutputDto>();
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
                        while(await reader.ReadAsync())
                        {
                            clientesOutputDtos = new List<UsuarioOutputDto>()
                            {
                                new UsuarioOutputDto()
                                {
                                    Id = reader.GetInt64(0),
                                    Nif = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Telefone = reader.GetString(4),
                                    Avatar = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }
            
            return Result<List<UsuarioOutputDto>>.Success(clientesOutputDtos, "Obtidas todas Agencia de Eventos com sucesso");
        }
        catch (Exception e)
        {
            return Result<List<UsuarioOutputDto>>.Error($"Erro ao obter Agencias de Eventos: {e.Message}");
        }
    }

    public Task<Result<List<UsuarioOutputDto>?>> ObterTodosPorPesquisa(string consulta)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> DeletarUsuario(int idUsuario)
    {
        throw new NotImplementedException();
    }
}