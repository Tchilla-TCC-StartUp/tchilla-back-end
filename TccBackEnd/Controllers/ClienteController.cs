using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly ClienteService _clienteService;
    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost("/cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteDto dto)
    {
        try
        {
            var id = await _clienteService.Cadastrar.Executar(dto);
            _logger.Log(LogLevel.Information, $"Cadastrado cliente {id} com sucesso");
            return CreatedAtAction(nameof(Cadastrar), new { id }, null);
        }
        catch (Exception e)
        { 
            return BadRequest(new {Error = e.Message});
        }
    }
}