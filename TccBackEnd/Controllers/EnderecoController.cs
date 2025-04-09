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
    
    [Authorize]
    [HttpPost("create/pais")]
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
    
    [Authorize]
    [HttpPost("create/provincia")]
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
    public async Task<IActionResult> Atualizar(int id,  Endereco endereco)
    {
        return Ok();
    }
    [HttpPut("update/Pais")]
    public async Task<IActionResult> AtualizarPais(int id,  Endereco endereco)
    {
        return Ok();
    }
    [HttpPut("update/Provincia")]
    public async Task<IActionResult> AtualizarProvincia(int id,  Endereco endereco)
    {
        return Ok();
    }
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> RemoverPorId(int id)
    {
        return Ok();
    }
    [HttpDelete("delete/Pais/{id:int}")]
    public async Task<IActionResult> RemoverPaisPorId(int id)
    {
        return Ok();
    }
    [HttpDelete("delete/Provincia/{id:int}")]
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
    [HttpGet("getAll")]
    public async Task<IActionResult> ObterTodosEnderecos()
    {
        return Ok();
    }
    [Authorize]
    [HttpGet("getAll/Pais")]
    public async Task<IActionResult> ObterTodosPaises(int id)
    {
        return Ok();
    }
    [Authorize]
    [HttpGet("getAll/Provincias/{paisId:int}")]
    public async Task<IActionResult> ObterTodosProvinciasPorPais(int paisId)
    {
        return Ok();
    }
    
}