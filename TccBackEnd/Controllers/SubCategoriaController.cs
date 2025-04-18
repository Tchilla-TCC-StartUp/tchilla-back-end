using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoriaController : ControllerBase
{
  private readonly ILogger<SubCategoriaController> _logger;
  private readonly SubCategoriaService _subCategoriaService;
  public SubCategoriaController(ILogger<SubCategoriaController> logger, SubCategoriaService subCategoriaService)
  {
    _logger = logger;
    _subCategoriaService = subCategoriaService;
  }

  [Authorize]
  [HttpPost("create")]
  public async Task<IActionResult> CriarSubCategoria([FromBody] CadastrarSubCategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _subCategoriaService.Cadastrar.Executar(dto);
    _logger.LogInformation("Solicitação de cadastro de SubCategoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpPut("update")]
  public async Task<IActionResult> AtualizarCategoria( int id, CadastrarSubCategoriaDto dto)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _subCategoriaService.Atualizar.Executar(id, dto);
    _logger.LogInformation("Solicitação de atualização de SubCategoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpDelete("Delete")]
  public async Task<IActionResult> RemoverCategoria(int id)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _subCategoriaService.Remover.Executar(id);
    _logger.LogInformation("Solicitação de remoção de SubCategoria");
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

    var result = await _subCategoriaService.ObterTodas.Executar();
    _logger.LogInformation("Solicitação de cadastro de SubCategoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }

  [Authorize]
  [HttpGet("getAll/{categoriaId}")]
  public async Task<IActionResult> ObterTodas(int categoriaId)
  {
    var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

    var result = await _subCategoriaService.ObterTodasPorCategoria.Executar(categoriaId);
    _logger.LogInformation("Solicitação de cadastro de SubCategoria");
    return result.IsSuccess
        ? Ok(result)
        : BadRequest(new { Error = result.ErrorMessage });
  }
}