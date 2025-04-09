using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Infra.Postgres.Repository;

public class SubCategoriaRepository : ISubCategoriaRepository
{
    private readonly string _connectionString;
    public SubCategoriaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public Task<Result<string>> CriarSubCategoria(SubCategoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> AtualizarSubCategoria(SubCategoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> RemoverSubCategoria(SubCategoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> ObterTodasSubCategorias(SubCategoria categoria)
    {
        throw new NotImplementedException();
    }
}