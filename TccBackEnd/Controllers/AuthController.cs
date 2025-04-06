using System.ComponentModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Auth.Dtos;
using TccBackEnd.UseCases.PrestadorServico.Dtos;
using TccBackEnd.UseCases.Usuario.Dtos;

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
  [AllowAnonymous]
  [HttpPost("register")]
  public async Task<IActionResult> register([FromBody] CadastrarUsuarioDto dto)
  {
    var result = await _authService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de usuário");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
  [AllowAnonymous]
  [HttpPost("register/prestador")]
  public async Task<IActionResult> CadastrarPrestador(CadastrarPrestadorDto dto)
  {
    var result = await _authService.CadastrarPrestador.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de local de eventos");
    return result.IsSuccess
      ? Ok(result)
      : BadRequest(new { Error = result.ErrorMessage });
  }
  
  [HttpPost("register/agencia")]
  public async Task<IActionResult> CadastrarAgencia([FromBody] CadastrarAgenciaEventosDto dto)
  {
    //Result<string> result = await _agenciaEventosService.Atualizar.Executar(dto);
    _logger.LogInformation($"Solicitação de atualização de Agencia de eventos");
    //return (result.IsSuccess) ? CreatedAtAction(nameof(Atualizar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    return Ok();
  }
  [AllowAnonymous]
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LogarCredenciaisDto dto)
  {
    var result = await _authService.Logar.Executar(dto);
    _logger.LogInformation("Solicitação de login");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpPut("logout")]
  public async Task<IActionResult> LogOut()
  {
    var userIdClaim = User.FindFirst("id");
    if (userIdClaim == null) 
      return Unauthorized(new { Error = "Usuário não autenticado" });

    int userId = int.Parse(userIdClaim.Value);
    var result = await _authService.LogOut.Executar(userId);
    _logger.LogInformation("Solicitação de logout");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
  
  [Authorize]
  [HttpPut("change-password")]
  public async Task<IActionResult> TrocarSenha(string oldPassword, string newPassword)
  {
    var userIdClaim = User.FindFirst("id");
    if (userIdClaim == null)
      return Unauthorized(new { Error = "Usuário não autenticado" });
        
    int userId = int.Parse(userIdClaim.Value);
    
    var result = await _authService.TrocarSenha.Executar(userId, oldPassword, newPassword);
    _logger.LogInformation("Solicitação de alteração de Senha de usuário");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
  [HttpPost("verify-email")]
  public async Task<IActionResult> VerificarEmail([FromBody] CadastrarUsuarioDto dto)
  {
    var result = await _authService.Cadastrar.Executar(dto);
    _logger.LogInformation("S4olicitação de cadastro de usuário");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }


}
