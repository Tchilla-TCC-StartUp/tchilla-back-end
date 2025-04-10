using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaisController : ControllerBase
{
    private readonly ILogger<PaisController> _logger;
    private readonly EnderecoService _enderecoService;
    public PaisController(ILogger<PaisController> logger, EnderecoService enderecoService)
    {
        _logger = logger;
        _enderecoService = enderecoService;
    }
    
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CriarPais([FromBody] CadastrarPaisDto dto)
    {
        var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        var result = await _enderecoService.CadastrarPais.Executar(dto);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Atualizar(int id,  Endereco endereco)
    {
        return Ok();
    }
  
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> RemoverPorId(int id)
    {
        return Ok();
    }
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        return Ok();
    }

    
}