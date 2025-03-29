using TccBackEnd.Service;

namespace TccBackEnd.Infra.Postgres.Repository;

public class LocalRepository
{
    private readonly string _connectionString;
    public LocalRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
}