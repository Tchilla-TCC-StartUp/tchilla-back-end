using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
  private readonly ILogger<CategoriaController> _logger;
  private readonly CategoriaService _categoriaService;
  public CategoriaController(ILogger<CategoriaController> logger, CategoriaService categoriaService)
  {
    _logger = logger;
    _categoriaService = categoriaService;
  }

  [Authorize]
  [HttpPost("create")]
  public async Task<IActionResult> CriarCategoria([FromBody] CategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _categoriaService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpPut("update")]
  public async Task<IActionResult> AtualizarCategoria(int id, CategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _categoriaService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpDelete("Delete")]
  public async Task<IActionResult> RemoverCategoria(int id, CategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _categoriaService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpGet("getAll")]
  public async Task<IActionResult> ObterTodas([FromBody] CategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _categoriaService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de categoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
}