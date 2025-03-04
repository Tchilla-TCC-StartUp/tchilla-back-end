using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.Auth.Dtos;
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

  [HttpPost("cliente/cadastrar")]
  public async Task<IActionResult> CadastrarCliente([FromBody] CadastrarClienteDto dto)
  {
    Result<string> result = await _authService.CadastrarCliente.Executar(dto);
    _logger.LogInformation($"Solicitação de cadastramento de Cliente");
    return (result.IsSuccess)
        ? Created(nameof(CadastrarCliente), result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
  [HttpPost("cliente/login")]
  public async Task<IActionResult> LogarCliente([FromBody] LogarCredenciaisDto dto)
  {
    var result = await _authService.LogarCliente.Executar(dto);
    _logger.LogInformation($"Solicitação de login de Cliente");
    return (result.IsSuccess)
      ? Created(nameof(LogarCliente), result)
      : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize("Cliente")]
  [HttpPut("cliente/logOut")]
  public async Task<IActionResult> LogOutCliente()
  {
    long userId = int.Parse(User.FindFirst("id")!.Value);
    var result = await _authService.LogOutCliente.Executar(userId);
    _logger.LogInformation($"Solicitação de LogOut de Cliente");
    return (result.IsSuccess)
      ? Created(nameof(LogOutCliente), result)
      : BadRequest(new { Error = result.ErrorMessage });
  }

  [HttpPost("agencia/cadastrar")]
  public async Task<IActionResult> CadastrarAgencia([FromBody] CadastrarAgenciaEventosDto dto)
  {
    Result<string> result = await _authService.CadastrarAgencia.Executar(dto);
    _logger.LogInformation($"Solicitação de cadastramento de Agencia de eventos");
    return (result.IsSuccess) ? Created(nameof(CadastrarAgencia), result) : BadRequest(new { Error = result.ErrorMessage });
  }

  [HttpPost("agencia/login")]
  public async Task<IActionResult> LogarAgencia([FromBody] LogarCredenciaisDto dto)
  {
    var result = await _authService.LogarCliente.Executar(dto);
    _logger.LogInformation($"Solicitação de login de Agência de Eventos");
    return (result.IsSuccess)
      ? Created(nameof(LogarCliente), result)
      : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize("Agencia")]
  [HttpPut("agencia/logOut")]
  public async Task<IActionResult> LogOutAgencia()
  {
    long userId = int.Parse(User.FindFirst("id")!.Value);
    var result = await _authService.LogOutCliente.Executar(userId);
    _logger.LogInformation($"Solicitação de LogOut de Cliente");
    return (result.IsSuccess)
      ? Created(nameof(LogOutCliente), result)
      : BadRequest(new { Error = result.ErrorMessage });
  }


}