using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly ILogger<EnderecoController> _logger;
    private readonly EnderecoService _enderecoService;
    public EnderecoController(ILogger<EnderecoController> logger, EnderecoService enderecoService)
    {
        _logger = logger;
        _enderecoService = enderecoService;
    }
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CriarEndereco([FromBody] CadastrarEnderecoDto dto)
    {
        var userId = User.FindFirstValue("id");
        if (userId == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        dto.UsuarioId = int.Parse(userId);

        var result = await _enderecoService.Cadastrar.Executar(dto);
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
    
    [Authorize]
    [HttpGet("getAll")]
    public async Task<IActionResult> ObterTodosEnderecos()
    {
        return Ok();
    }
    
}