// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var c = new swaggerClient("https://localhost:7071/", new HttpClient());
c.GetWeatherForecastAsync(new object());

var fc = new WeatherForecast();
fc.Part = PartOfDay.Evening;