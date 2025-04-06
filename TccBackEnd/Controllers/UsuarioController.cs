using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Usuario.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly UsuarioService _usuarioService;
    
    public UsuarioController(ILogger<UsuarioController> logger, UsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }
    [Authorize]
    [HttpGet("getInfoByToken")]
    public async Task<IActionResult> ObterUsuarioPorToken()
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null) 
            return Unauthorized(new { Error = "Usuário não autenticado" });

        var userId = int.Parse(userIdClaim.Value);
        Result<UsuarioOutputDto?> result = await _usuarioService.ObterPorId.Executar(userId);
        _logger.LogInformation("Solicitação de usuario por token.");
        
        return result.IsSuccess 
            ? Ok(result) 
            : BadRequest(new { Error = result.ErrorMessage });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarUsuarioDto dto)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null) 
            return Unauthorized(new { Error = "Usuário não autenticado" });

        dto.Id = int.Parse(userIdClaim.Value);
        
        Result<string> result = await _usuarioService.Atualizar.Executar(dto);
        _logger.LogInformation("Solicitação de atualização de usuário.");
        
        return result.IsSuccess 
            ? Ok(new { Mensagem = "Perfil atualizado com sucesso." }) 
            : BadRequest(new { Error = result.ErrorMessage });
    }


    [HttpGet("getAll")]
    public async Task<IActionResult> ObterTodos()
    {
        Result<List<UsuarioOutputDto?>> result = await _usuarioService.ObterTodos.Executar();
        _logger.LogInformation($"Solicitação de obtenção de todos usuarios.");
        
        return result.IsSuccess 
            ? Ok(result) 
            : NotFound(new { Error = result.ErrorMessage });
    }

    [HttpGet("getOne/{id:int}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        Result<List<UsuarioOutputDto>?> result = await _usuarioService.ObterTodos.Executar();
        _logger.LogInformation("Solicitação de obtenção de todos os usuários.");
        
        return result.IsSuccess 
            ? Ok(result) 
            : BadRequest(new { Error = result.ErrorMessage });
    }


    [HttpGet("obterPorPesquisa")]
    public async Task<IActionResult> ObterPorPesquisa([FromQuery] string consulta)
    {
        Result<List<UsuarioOutputDto>?> result = await _usuarioService.ObterTodosPorPesquisa.Executar(consulta);
        _logger.LogInformation($"Solicitação de pesquisa de usuários com o termo: {consulta}.");
        
        return result.IsSuccess 
            ? Ok(result) 
            : BadRequest(new { Error = result.ErrorMessage });
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        Result<string> result = await _usuarioService.Deletar.Executar(id);
        _logger.LogInformation($"Solicitação de exclusão do usuário com ID {id}.");
        
        return result.IsSuccess 
            ? Ok(new { Mensagem = "Usuário deletado com sucesso." }) 
            : BadRequest(new { Error = result.ErrorMessage });
    }
}
