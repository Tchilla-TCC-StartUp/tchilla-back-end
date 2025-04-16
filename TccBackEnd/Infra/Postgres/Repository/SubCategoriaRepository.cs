using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using Npgsql;
using TccBackEnd.UseCases.SubCategoria.Dtos;
using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Infra.Postgres.Repository;

public class SubCategoriaRepository : ISubCategoriaRepository
{
    private readonly string _connectionString;

    public SubCategoriaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Result<string>> CriarSubCategoria(SubCategoria subCategoria)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO subcategoria (nome, tipo, categoriaid) VALUES (@Nome, @Tipo, @CategoriaId)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", subCategoria.Nome);
                    command.Parameters.AddWithValue("@Tipo", subCategoria.Tipo.ToString());
                    command.Parameters.AddWithValue("@CategoriaId", subCategoria.CategoriaId);
                    command.Parameters.AddWithValue("@Descricao", subCategoria.Descricao);
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                        return Result<string>.Success("Subcategoria criada com sucesso");
                    else
                        return Result<string>.Error("Erro ao criar subcategoria");
                }
            }
        }
        catch (Exception ex)
        {
            return Result<string>.Error("Erro ao criar subcategoria: " + ex.Message);
        }
    }

    public async Task<Result<string>> AtualizarSubCategoria(SubCategoria subCategoria)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE subcategoria SET nome = @Nome, tipo = @Tipo, categoriaid = @CategoriaId WHERE id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", subCategoria.Id);
                    command.Parameters.AddWithValue("@Nome", subCategoria.Nome);
                    command.Parameters.AddWithValue("@Tipo", subCategoria.Tipo.ToString());
                    command.Parameters.AddWithValue("@CategoriaId", subCategoria.CategoriaId);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                        return Result<string>.Success("Subcategoria atualizada com sucesso");
                    else
                        return Result<string>.Error("Subcategoria não encontrada");
                }
            }
        }
        catch (Exception ex)
        {
            return Result<string>.Error("Erro ao atualizar subcategoria: " + ex.Message);
        }
    }

    public async Task<Result<string>> RemoverSubCategoria(int id)
    {
        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM subcategoria WHERE id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                        return Result<string>.Success("Subcategoria removida com sucesso");
                    else
                        return Result<string>.Error("Subcategoria não encontrada");
                }
            }
        }
        catch (Exception ex)
        {
            return Result<string>.Error("Erro ao remover subcategoria: " + ex.Message);
        }
    }

    public async Task<Result<List<SubCategoriaOutPutDto>>> ObterTodasSubCategorias()
    {
        List<SubCategoriaOutPutDto> subCategorias = new List<SubCategoriaOutPutDto>();

        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT id, nome, tipo, categoriaid, descricao FROM subcategoria";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subCategorias.Add(
                                new SubCategoriaOutPutDto
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    Tipo = (SubCategoriaTipo)Enum.Parse(typeof(SubCategoriaTipo), reader.GetString(2)),
                                    CategoriaId = reader.GetInt32(3),
                                    Descricao = reader.GetString(4)
                                }
                            );
                        }
                        return Result<List<SubCategoriaOutPutDto>>.Success(subCategorias, "Subcategorias obtidas com sucesso");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return Result<List<SubCategoriaOutPutDto>>.Error($"Erro ao carregar subcategorias: {ex.Message}");
        }
    }

    public async Task<Result<List<SubCategoriaOutPutDto>>> ObterTodasSubCategoriasPorCategoria(int categoriaId)
    {
        List<SubCategoriaOutPutDto> subCategorias = new List<SubCategoriaOutPutDto>();

        try
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT id, nome, tipo, categoriaid FROM subcategoria where categoriaid = @CategoriaId";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subCategorias.Add(
                                new SubCategoriaOutPutDto
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    CategoriaId = reader.GetInt32(3),
                                    Tipo = (SubCategoriaTipo)Enum.Parse(typeof(SubCategoriaTipo), reader.GetString(2))
                                }
                            );
                        }
                        return Result<List<SubCategoriaOutPutDto>>.Success(subCategorias, "Subcategorias obtidas com sucesso");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return Result<List<SubCategoriaOutPutDto>>.Error($"Erro ao carregar subcategorias: {ex.Message}");
        }
    }
}