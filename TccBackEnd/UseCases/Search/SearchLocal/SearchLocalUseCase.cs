using TccBackEnd.Domain.Interfaces;

namespace TccBackEnd.UseCases.Search;

public class SearchLocalUseCase {
  private readonly ISearchRepository _repository;

  public SearchLocalUseCase(ISearchRepository repository)
  {
    _repository = repository;
  }

  
}