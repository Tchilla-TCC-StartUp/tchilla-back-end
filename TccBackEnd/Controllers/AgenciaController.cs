using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.Auth.Dtos;

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
    
    [Authorize]
    [HttpGet("getInfoByToken")]
    public async Task<IActionResult> ObterUsuarioPorToken()
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null) 
            return Unauthorized(new { Error = "Usuário não autenticado" });

        var userId = int.Parse(userIdClaim.Value);
        /*Result<UsuarioOutputDto?> result = await _usuarioService.ObterPorId.Executar(userId);
        _logger.LogInformation("Solicitação de usuario por token.");

        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });**/
        return Ok();
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAgenciaEventosDto dto)
    {
        //Result<string> result = await _agenciaEventosService.Atualizar.Executar(dto);
        _logger.LogInformation($"Solicitação de atualização de Agencia de eventos");
        //return (result.IsSuccess) ? CreatedAtAction(nameof(Atualizar), result, null) : BadRequest(new {Error = result.ErrorMessage});
        return Ok();
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> ObterPorId([FromQuery] int id)
    {
        Result<AgenciaEventosOutputDto?> result = await _agenciaEventosService.ObterPorId.Executar(id);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterPorId), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> ObterTodos()
    {
        Result<List<AgenciaEventosOutputDto?>> result = await _agenciaEventosService.ObterTodas.Executar();
        _logger.LogInformation($"Solicitação de obtenção de  todas Agencias de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodos), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet("getAll/{consulta}")]
    public async Task<IActionResult> ObterTodasPorPesquisa(string consulta)
    {
        Result<List<AgenciaEventosOutputDto>?> result = await _agenciaEventosService.ObterTodasPorPesquisa.Executar(consulta);
        _logger.LogInformation($"Solicitação de obtenção de Agencia de eventos");
        return (result.IsSuccess) ? CreatedAtAction(nameof(ObterTodasPorPesquisa), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
}