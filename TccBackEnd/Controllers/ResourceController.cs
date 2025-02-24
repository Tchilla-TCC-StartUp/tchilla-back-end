using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    public IActionResult Welcome([FromQuery] string lang = "pt")
    {
        lang = lang?.ToLower() ?? "pt"; 

        string baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/images/";

        var welcomeMessages = new Dictionary<string, object>
        {
            ["pt"] = new
            {
                titulo = "Seja bem-vindo ao Tchilla",
                url = $"{baseUrl}Welcome-cuate 1.png",
                descricao = "Estamos gratos por ter baixado o nosso aplicativo. Crie uma conta, faça login ou explore o app."
            },
            ["en"] = new
            {
                titulo = "Welcome to Tchilla",
                url = $"{baseUrl}Welcome-cuate 1.png",
                descricao = "We are grateful that you downloaded our app. Create an account, log in, or explore the app."
            }
        };

        return Ok(welcomeMessages.ContainsKey(lang) ? welcomeMessages[lang] : welcomeMessages["en"]);
    }

    [HttpGet("onboarding")]
    public IActionResult OnBoarding([FromQuery] string lang = "pt")
    {
        lang = lang?.ToLower() ?? "pt"; 

        string baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/images/";

        var onboardingSlides = new Dictionary<string, List<object>>
        {
            ["pt"] = new List<object>
            {
                new
                {
                    titulo = "Economize tempo na sua busca.",
                    url = $"{baseUrl}House searching-cuate.svg",
                    descricao = "Com apenas alguns cliques, encontre o local ideal para qualquer evento social com as melhores opções."
                },
                new
                {
                    titulo = "Serviços de decoração no pacote",
                    url = $"{baseUrl}Wedding planner-cuate.svg",
                    descricao = "Aproveite o momento para reservar o que deseja para o seu evento."
                },
                new
                {
                    titulo = "Compare e avalie com confiança",
                    url = $"{baseUrl}Wedding-cuate.svg",
                    descricao = "Escolha a melhor opção com base nas avaliações e comparações."
                }
            },
            ["en"] = new List<object>
            {
                new
                {
                    title = "Save time in your search.",
                    url = $"{baseUrl}House searching-cuate.svg",
                    description = "With just a few clicks, find the ideal place for any social event with the best options."
                },
                new
                {
                    title = "Decoration services included in the package",
                    url = $"{baseUrl}Wedding planner-cuate.svg",
                    description = "Take advantage of the moment to book what you need for your event."
                },
                new
                {
                    titulo = "Compare and evaluate with confidence",
                    url = $"{baseUrl}Wedding-cuate.svg",
                    descricao = "Choose the best option based on reviews and comparisons."
                }
            }
        };

        return Ok(onboardingSlides.ContainsKey(lang) ? onboardingSlides[lang] : onboardingSlides["en"]);
    }
}
