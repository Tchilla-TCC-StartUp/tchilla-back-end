using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvinciaController : ControllerBase
{
    private readonly ILogger<ProvinciaController> _logger;
    private readonly EnderecoService _enderecoService;
    public ProvinciaController(ILogger<ProvinciaController> logger, EnderecoService enderecoService)
    {
        _logger = logger;
        _enderecoService = enderecoService;
    }
       
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CriarProvincia([FromBody] CadastrarProvinciaDto dto)
    {
        var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });

        var result = await _enderecoService.CadastrarProvincia.Executar(dto);
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> AtualizarProvincia(int id,  Endereco endereco)
    {
        return Ok();
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> RemoverProvinciaPorId(int id)
    {
        return Ok();
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        return Ok();
    }

    [Authorize]
    [HttpGet("getAll/{paisId:int}")]
    public async Task<IActionResult> ObterTodosProvinciasPorPais(int paisId)
    {
        return Ok();
    }
    
}