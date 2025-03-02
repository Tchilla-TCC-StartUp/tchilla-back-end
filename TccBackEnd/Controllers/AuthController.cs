using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly ILogger<AuthController> _logger;
  private readonly AuthService _authService;
  public AuthController(ILogger<AuthController> logger, AuthService authService)
  {
    _logger = logger;
    _authService = authService;
  }

  [HttpPost("cadastrar")]
  public async Task<IActionResult> CadastrarCliente([FromBody] CadastrarClienteDto dto)
  {
    Result<string> result = await _authService.CadastrarCliente.Executar(dto);
        _logger.LogInformation($"Solicitação de cadastramento de Agencia de eventos");
        return (result.IsSuccess)
            ? CreatedAtAction(nameof(CadastrarCliente), result, null)
            : BadRequest(new { Error = result.ErrorMessage });    
  }  
  [HttpPost("cliente/login")]
  public async Task<IActionResult> LogarCliente([FromBody] LogarClienteDto dto)
  {
    var result = await _authService.LogarCliente.Executar(dto);
    _logger.LogInformation($"Solicitação de login de Cliente");
    return (result.IsSuccess)
      ? CreatedAtAction(nameof(LogarCliente), result, null)
      : BadRequest(new {Error = result.ErrorMessage});
  }

    
}