using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestadorController : Controller
{
    private readonly ILogger<PrestadorController> _logger;
    private readonly CadastrarPrestadorServicoUseCase _cadastrarPrestadorServicoUseCase;
    public PrestadorController(ILogger<PrestadorController> logger, CadastrarPrestadorServicoUseCase _cadastrarPrestadorServicoUseCase)
    {
        _logger = logger;
        _cadastrarPrestadorServicoUseCase = _cadastrarPrestadorServicoUseCase;
    }

   
    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(CadastrarPrestadorServicoDto dto)
    {
        try
        {
            var id = await _cadastrarPrestadorServicoUseCase.Executar(dto);
            return CreatedAtAction(nameof(Cadastrar), new { id }, null);
        }
        catch (Exception e)
        {
            return BadRequest(new {Error = e.Message});
        }
    }
}