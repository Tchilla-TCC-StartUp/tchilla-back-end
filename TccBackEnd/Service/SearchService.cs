using TccBackEnd.UseCases.Search;

namespace TccBackEnd.Service;

public class SearchService
{
  public SearchLocalUseCase searchLocalUseCase {get;}
  public SearchService(
    SearchLocalUseCase searchlocalUseCase
  ) {
    searchLocalUseCase = searchlocalUseCase;
  }
}