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
public class AuthController : ControllerBase
{
  private readonly ILogger<AuthController> _logger;
  private readonly AuthService _authService;
  public AuthController(ILogger<AuthController> logger, AuthService authService)
  {
    _logger = logger;
    _authService = authService;
  }

  [HttpPost("cliente/login")]
  public async Task<IActionResult> LogarCliente()
  {
    return Ok();
  }

    
}