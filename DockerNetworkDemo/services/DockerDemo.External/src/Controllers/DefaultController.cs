using System.Text.Json;
using DockerDemo.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.External.Controllers;

[ApiController]
public class DefaultController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAppInfo()
    {
        return Content(JsonSerializer.Serialize(AppInfoHelper.GetAppInfoDictionary()), "application/json");
    }
}