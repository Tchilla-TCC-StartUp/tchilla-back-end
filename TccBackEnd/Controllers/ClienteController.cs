using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly ClienteService _clienteService;
    public ClienteController(ILogger<ClienteController> logger, ClienteService clienteService)
    {
        _logger = logger;
        _clienteService = clienteService;
    }

    [HttpPut("atualizarPerfil")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarClienteDto dto)
    {
        Result<string> result = await _clienteService.Atualizar.Executar(dto);
        _logger.LogInformation($"Solicitação de atualização de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(Atualizar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("obterPorId")]
    public async Task<IActionResult> ObterPorId([FromQuery] long id)
    {
        Result<ClienteOutputDto?> result = await _clienteService.ObterPorId.Executar(id);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterPorId), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("obterTodos")]
    public async Task<IActionResult> ObterTodos()
    {
        Result<List<ClienteOutputDto>?> result = await _clienteService.ObterTodos.Executar();
        _logger.LogInformation($"Solicitação de obtenção de  todas Agencias de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodos), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("ObterTodasPorPesquisa")]
    public async Task<IActionResult> ObterTodasPorPesquisa([FromQuery] string consulta)
    {
        Result<List<ClienteOutputDto>?> result = await _clienteService.ObterTodosPorPesquisa.Executar(consulta);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodasPorPesquisa), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
}