using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly CadastrarClienteUseCase _cadastrarClienteUseCase;
    public ClienteController(CadastrarClienteUseCase cadastrarClienteUseCase)
    {
        _cadastrarClienteUseCase = cadastrarClienteUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteDto dto)
    {
        try
        {
            var id = await _cadastrarClienteUseCase.Executar(dto);
            _logger.Log(LogLevel.Information, $"Cadastrado cliente {id} com sucesso");
            return CreatedAtAction(nameof(Cadastrar), new { id }, null);
        }
        catch (Exception e)
        { 
            return BadRequest(new {Error = e.Message});
        }
    }
}