using Microsoft.AspNetCore.Mvc;

namespace DockerDemo.External.Controllers;

[ApiController]
[Route("{controller}")]
public class InternalApiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public InternalApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAppInfo()
    {
        var res = await _httpClient.GetAsync("http://api-internal/");

        return Content(await res.Content.ReadAsStringAsync(), "application/json");
    }
}