using Microsoft.AspNetCore.Mvc;

namespace Labs.GithubAction.Controllers;

[ApiController, ApiVersion("1.0")]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHelloMessage()
    {
        return Ok("Hello from DemoController");
    }
}