using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherApp.Models;

public class WeatherController : Controller
{
    private readonly HttpClient _httpClient;

    public WeatherController(IHttpClientFactory httpClientFactory) // Use IHttpClientFactory
    {
        _httpClient = httpClientFactory.CreateClient(); // Create HttpClient instance
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city)
    {
        var url = $"https://weather-api138.p.rapidapi.com/weather?city_name={city}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("x-rapidapi-host", "weather-api138.p.rapidapi.com");
        request.Headers.Add("x-rapidapi-key", "21d7ff4027mshe304dc10a4523b9p1e4171jsn216fcad595cd"); // Replace with your actual RapidAPI key

        try
        {
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var weatherInfo = JsonConvert.DeserializeObject<WeatherData>(responseData);
                return View("Index", weatherInfo);
            }
            else
            {
                ModelState.AddModelError("", "Unable to fetch weather data. Please try again.");
                return View("Index");
            }
        }
        catch
        {
            ModelState.AddModelError("", "An error occurred while fetching weather data.");
            return View("Index");
        }
    }
}
