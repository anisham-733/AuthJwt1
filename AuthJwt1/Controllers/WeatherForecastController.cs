using AuthJwt1.Models;
using AuthJwt1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthJwt1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITokenHandler tokenHandler;
        private readonly MydatabaseContext mydatabaseContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ITokenHandler tokenHandler,MydatabaseContext mydatabaseContext)
        {
            _logger = logger;
            this.tokenHandler = tokenHandler;
            this.mydatabaseContext = mydatabaseContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            //var user = <if user exists>
            var item=mydatabaseContext.TodoItems.FirstOrDefault();
            var token =  tokenHandler.CreateTokenAsync(item);
            Console.WriteLine(token.Result);


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            
        }
    }
}