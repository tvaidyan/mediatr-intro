using MediatR;

namespace mediatr_intro
{
	public class WeatherForecastRequest : IRequest<WeatherForecastResponse>
	{
		// your request params will go here
	}

	public class GetWeatherForecastHandler : IRequestHandler<WeatherForecastRequest, WeatherForecastResponse>
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public async Task<WeatherForecastResponse> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var weatherForecastResponse = new WeatherForecastResponse
            {
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            };
            return await Task.FromResult(weatherForecastResponse);
		}
    }

	public class WeatherForecastResponse
	{
		public IEnumerable<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();
	}
}

