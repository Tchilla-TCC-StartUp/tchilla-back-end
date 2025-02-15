using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgenciaController : ControllerBase
{
    private readonly ILogger<AgenciaController> _logger;
    private readonly AgenciaEventosService _agenciaEventosService;
    public AgenciaController(ILogger<AgenciaController> logger, AgenciaEventosService agenciaEventosService)
    {
        _logger = logger;
        _agenciaEventosService = agenciaEventosService;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarAgenciaEventosDto dto)
    {
        Result<string> result = await _agenciaEventosService.Cadastrar.Executar(dto);
        _logger.LogInformation($"Solicitação de cadastramento de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(Cadastrar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAgenciaEventosDto dto)
    {
        Result<string> result = await _agenciaEventosService.Atualizar.Executar(dto);
        _logger.LogInformation($"Solicitação de atualização de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(Atualizar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("obterPorId")]
    public async Task<IActionResult> ObterPorId([FromQuery] long id)
    {
        Result<AgenciaEventosOutputDto?> result = await _agenciaEventosService.ObterPorId.Executar(id);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterPorId), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("obterTodos")]
    public async Task<IActionResult> ObterTodos()
    {
        Result<List<AgenciaEventosOutputDto?>> result = await _agenciaEventosService.ObterTodas.Executar();
        _logger.LogInformation($"Solicitação de obtenção de  todas Agencias de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodos), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("ObterTodasPorPesquisa")]
    public async Task<IActionResult> ObterTodasPorPesquisa([FromQuery] string consulta)
    {
        Result<List<AgenciaEventosOutputDto>?> result = await _agenciaEventosService.ObterTodasPorPesquisa.Executar(consulta);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodasPorPesquisa), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
}