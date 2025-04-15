using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnumController : ControllerBase
{
  [HttpGet("enums")]
  public IActionResult GetEnumValues()
  {
    var enumType = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.IsEnum);

    if (enumType == null)
      return NotFound();

    var values = new List<object>();

    foreach (var type in enumType)
    {

      values.Add(
       new
       {
         type.Name,
         Values = Enum.GetNames(type).Cast<object>().ToList()
       }
      );
    }

    return Ok(values);
  }

  [HttpGet("{enumName}")]
  public IActionResult GetEnumValues(string enumName)
  {
    var enumType = Assembly.GetExecutingAssembly()
        .GetTypes()
        .FirstOrDefault(t => t.IsEnum && t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));

    if (enumType == null)
      return NotFound();

    var values = Enum.GetNames(enumType);

    return Ok(values);
  }
}
