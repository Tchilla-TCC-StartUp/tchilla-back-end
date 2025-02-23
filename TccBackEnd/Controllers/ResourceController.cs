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
  public ResourceController(ILogger<ResourceController> logger)
  {
    _logger = logger;
  }
  [HttpGet("welcome")]
  public IActionResult Welcome()
  {
    string baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/images/";

    object welcome = new 
    {
      titulo = "Seja bem vindo ao Tchilla",
      url = $"{baseUrl}Welcome-cuate 1.png",
      descricao = "Estamos grato por ter baixado o nosso aplicativo, crie conta, faz login, ou explore a App."
    };
    
    return Ok(welcome);    
  }

  [HttpGet("onboarding")]
  public IActionResult OnBoarding()
  {
    string baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/images/";

    List<object> onboardingSlides = new List<object> {
      new 
      {
        titulo = "Economize tempo na sua busca.",
        url = $"{baseUrl}House searching-cuate.png",
        descricao = "Com apenas alguns cliques, encontre o local ideal para qualquer evento social com as melhores opcoes "
      },
      new 
      {
        titulo = "Servicos de decoracao no pacote",
        url = $"{baseUrl}Weddingplanner-cuate.png",
        descricao = "Take advantage of the moment to reserve what you want to eat today, don’t wait for tomorrow."
      },
      new 
      {
        titulo = "Compare, avalie  com confianca",
        url = $"{baseUrl}Wedding-cuate.png",
        descricao = "Take advantage of the moment to reserve what you want to eat today, don’t wait for tomorrow."
      }
    };  
    
    
    return Ok(onboardingSlides);    
  }
}