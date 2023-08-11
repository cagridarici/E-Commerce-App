using E_Commerce.Application;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private ApplicationRepository<Order> _OrderRepository = null;
        private ApplicationRepository<Product> _ProductRepository = null;
        private OrderAppService _OrderAppService = null;

        public WeatherForecastController(OrderAppService service,ApplicationRepository<Order> orderRepository,
            ApplicationRepository<Product> productRepository,
            ILogger<WeatherForecastController> logger)
        {
            _OrderAppService = service;
            _OrderRepository = orderRepository;
            _ProductRepository = productRepository;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}