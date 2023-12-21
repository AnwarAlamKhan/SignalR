using Microsoft.AspNetCore.Mvc;

using RestSharp;
using System.Diagnostics;
using WebAppFrontEnd.Models;
using System.Text.Json;
using WebAppFrontEnd.Utility;
using System.Threading.Tasks;

namespace WebAppFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BaseRestClient _restClient;

        public HomeController(ILogger<HomeController> logger, BaseRestClient restClient)
        {
            _logger = logger;
            _restClient = restClient;
        }
        private void RequestTimeoutCheck(RestRequest request, RestResponse response)
        {
            if (response.StatusCode == 0)
            {
                // log te response and request details
            }
        }

        private string GetToken()
        {

            RestRequest request = new RestRequest("https://localhost:7060/api/Login/Login", Method.Get);

            //request.AddQueryParameter("userLogin", "Anwar");
            request.AddParameter("userLogin", "Anwar");
            // RestSharp.Parameter p = new RestSharp.Parameter

            var response = _restClient.Execute(request).Result;

            var result = JsonSerializer.Deserialize<string>(response.Content.ToString());
            return result;
        }


        public IActionResult Index()
        {
            var token = "Bearer " + GetToken().ToString();
            RestRequest request = new RestRequest("https://localhost:7060/WeatherForecast", Method.Get);

            request.AddHeader("Authorization", token);


            var response = _restClient.Execute(request).Result.Content;

            List<PageData> lst = new List<PageData>();
            lst = JsonSerializer.Deserialize<List<PageData>>(response);

            return View(lst);
        }
        
        public IActionResult Count()
        {
            return View();
        }

        public IActionResult LoadDBList()
        {
            

            return View();
        }
        public IActionResult DBList()
        {
            RestRequest request = new RestRequest("https://localhost:7060/api/Login/GetSubscribers", Method.Get);
            var response = _restClient.Execute(request).Result;
            return Ok(response.Content);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}