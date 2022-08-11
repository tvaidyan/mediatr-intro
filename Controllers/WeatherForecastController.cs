using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mediatr_intro.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator mediator;

    public WeatherForecastController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<WeatherForecastResponse> Get()
    {
        return await mediator.Send(new WeatherForecastRequest());
    }
}
