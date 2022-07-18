using Microsoft.AspNetCore.Mvc;

namespace Labs.GithubAction.Controllers.V2;

[ApiController, ApiVersion("2.0")]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
   {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 我是版本二的文件
    /// </summary>
    /// <param name="apa">asdasdasd</param>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get(string apa)
    {
        return new ContentResult()
        {
            Content = "I am version 2",
            ContentType = "text/plain;charset=utf-8",
            StatusCode = StatusCodes.Status200OK
        };
    }
}
