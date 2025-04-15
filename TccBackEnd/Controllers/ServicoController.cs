using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Servico.Cadastrar;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
  private readonly ILogger<ServiceController> _logger;
  private readonly ServicoService _servicoService;
  public ServiceController(ILogger<ServiceController> logger, ServicoService servicoService)
  {
    _logger = logger;
    _servicoService = servicoService;
  }

  [Authorize]
  [HttpPost("create")]
  public async Task<IActionResult> CriarServico([FromBody] CadastrarServicoDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
    
    dto.OwnerId = int.Parse(userId);
    var prestador = User.FindFirstValue("prestador");
    var agencia = User.FindFirstValue("agencia");

    var result = await _servicoService.Cadastrar.Executar((prestador!=null ? prestador : agencia), dto);
    _logger.LogInformation("Solicitação de cadastro de Serviço");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpPut("update")]
  public async Task<IActionResult> AtualizarCategoria(int id, ServicoDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _servicoService.Atualizar.Executar(id, dto);
    _logger.LogInformation("Solicitação de atualização de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpDelete("Delete")]
  public async Task<IActionResult> RemoverCategoria([FromBody] int id)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _servicoService.Remover.Executar(id);
    _logger.LogInformation("Solicitação de cadastro de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpGet("getAll")]
  public async Task<IActionResult> ObterTodas()
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _servicoService.ObterTodas.Executar();
    _logger.LogInformation("Solicitação de todas categorias");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
}