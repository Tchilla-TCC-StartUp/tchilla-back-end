using Npgsql;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;

namespace TccBackEnd.Infra.Postgres.Repository;

public class PrestadorServicoRepository : IPrestadorRepository
{
    private readonly string _connectionString;
    public PrestadorServicoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }


    public Task<Prestador?> ObterPrestadorServicoPorId(long id)
    {
        throw new NotImplementedException();
    }
}