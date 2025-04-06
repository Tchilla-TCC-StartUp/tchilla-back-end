using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.PrestadorServico.Dtos;
using TccBackEnd.UseCases.Search.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : Controller
{
    private readonly ILogger<SearchController> _logger;
    private readonly SearchService _searchService;
    public SearchController(ILogger<SearchController> logger, SearchService searchService)
    {
        _logger = logger;
        _searchService = searchService;
    }

    [HttpGet("local")]
    public async Task<IActionResult> PesquisarLocal(SearchLocalInputDto dto)
    {
        return Ok();
    }

    [HttpGet("servico")]
    public async Task<IActionResult> PesquisarServicos()
    {
        return Ok();
    }
    [HttpGet("produto")]
    public async Task<IActionResult> PesquisarProduto()
    { 
        return Ok();
    }
        
    [HttpGet("localServicosOrprodutos")]
    public async Task<IActionResult> PesquisarLocalServicosOrProdutos()
    {
        return Ok();
    }
    
    
}