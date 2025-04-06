using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Infra.Postgres.Repository;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly string _connectionString;

    public EnderecoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Result<string>> CriarEndereco(Endereco endereco)
    {
        try
        {
            if(endereco is null)
                throw new ArgumentNullException(nameof(endereco));

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var queryInsert = "insert into endereco(numero, rua, cidade, provinciaId, cep, latitude, longitude, usuarioId, principal)";
                var queryValues = "Values(@numero, @rua, @cidade, @provinciaId, @cep, @latitude, @longitude, @usuarioId, @principal)";

                using (var command = new NpgsqlCommand($"{queryInsert} {queryValues}", connection))
                {
                    command.Parameters.AddWithValue("@numero", endereco.Numero);
                    command.Parameters.AddWithValue("@rua", endereco.Rua);
                    command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                    command.Parameters.AddWithValue("@provinciaId", endereco.ProvinciaId);
                    command.Parameters.AddWithValue("@cep", endereco.Cep);
                    command.Parameters.AddWithValue("@latitude", endereco.Latitude);
                    command.Parameters.AddWithValue("@longitude", endereco.Longitude);
                    command.Parameters.AddWithValue("@usuarioId", endereco.UsuarioId);
                    command.Parameters.AddWithValue("@principal", endereco.Principal);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Cadastrado Endereço com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar novo Endereço: {e}");
        }
    }

    public async Task<Result<string>> CriarPais(Pais pais)
    {
        try
        {
            if(pais is null)
                throw new ArgumentNullException(nameof(pais));

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var queryInsert = "insert into pais(nome, codigo_iso)";
                var queryValues = "Values(@nome, @codigo_iso";

                using (var command = new NpgsqlCommand($"{queryInsert} {queryValues}", connection))
                {
                    command.Parameters.AddWithValue("@nome", pais.Nome);
                    command.Parameters.AddWithValue("@codigo_iso", pais.CodigoIso);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Cadastrado Paísz com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar novo País: {e}");
        }
    }

    public async Task<Result<string>> CriarProvincia(Provincia provincia)
    {
        try
        {
            if(provincia is null)
                throw new ArgumentNullException(nameof(provincia));

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var queryInsert = "insert into provincia(nome, codigo_iso)";
                var queryValues = "Values(@nome, @paisId";

                using (var command = new NpgsqlCommand($"{queryInsert} {queryValues}", connection))
                {
                    command.Parameters.AddWithValue("@nome", provincia.Nome);
                    command.Parameters.AddWithValue("@paisId", provincia.PaisId);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }

            return Result<string>.Success("Cadastrado Provincia com sucesso");
        }
        catch (Exception e)
        {
            return Result<string>.Error($"Erro ao Cadastrar nova Província: {e}");
        }
    }

    public Task<Result<string>> AtualizarEndereco()
    {
        throw new NotImplementedException();
    }
}