using TccBackEnd.Domain.Interfaces;

namespace TccBackEnd.Infra.Postgres.Repository;

public class SearchRepository : ISearchRepository 
{
  private readonly string _connectionString;

  public SearchRepository(string connectionString)
  {
    _connectionString = connectionString;
  }
}