using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using WebClientApiKey;

namespace WebApplication30.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IswaggerClient _swaggerClient;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IswaggerClient swagger)
        {
            _logger = logger;
            _configuration = configuration;
            _swaggerClient = swagger;
        }

        public async Task OnGet()
        {
            //var headerName = "X-Api-Key";
            //var headerValue = _configuration.GetValue<string>("ApiKey");

            //using var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add(headerName, headerValue);

           // var api = new swaggerClient("https://localhost:7071/", httpClient);
            try
            {
                var z = await _swaggerClient.GetWeatherForecastAsync();
            }
            catch (Exception e)
            {

                throw;
            }
         
        }
    }
}