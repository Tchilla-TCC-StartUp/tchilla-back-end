using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourceController : Controller
{
  private readonly ILogger<ResourceController> _logger;
  private readonly IWebHostEnvironment _env;
  public ResourceController(ILogger<ResourceController> logger)
  {
    _logger = logger;
  }

  [HttpGet("onboarding")]
  public async Task<IActionResult> OnBoarding()
  {
    string folderPath = Path.Combine(_env.WebRootPath, "Resources/images");

        if (!Directory.Exists(folderPath))
            return NotFound("A pasta de imagens não existe.");

        var images = Directory.GetFiles(folderPath)
            .Select(file => new
            {
                nome = Path.GetFileName(file),
                url = $"{Request.Scheme}://{Request.Host}/Resources/images/{Path.GetFileName(file)}"
            });

        return Ok(images);
  }
}