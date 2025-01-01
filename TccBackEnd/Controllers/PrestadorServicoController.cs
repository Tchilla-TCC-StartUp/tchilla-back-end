using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestadorServicoController : Controller
{
    private readonly CadastrarPrestadorServicoUseCase _cadastrarPrestadorServicoUseCase;
    public PrestadorServicoController(CadastrarPrestadorServicoUseCase _cadastrarPrestadorServicoUseCase)
    {
        _cadastrarPrestadorServicoUseCase = _cadastrarPrestadorServicoUseCase;
    }

    [HttpPost]
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