using HotelMVC.Models;
using HotelMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http.Headers;

namespace HotelMVC.Controllers.Client
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        string Baseurl = "https://localhost:44384/api/";

        public async Task<ActionResult> Index()
        {
            List<Branch> BranchInfo = new List<Branch>();

            
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Branchs");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var BranchResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    BranchInfo = JsonConvert.DeserializeObject<List<Branch>>(BranchResponse);
                }
                //returning the employee list to view

                HomeVM homeVM = new HomeVM();
                homeVM.Branchs = BranchInfo;
                homeVM.SearshInHome = new SearshInHome();

                return View(homeVM);
            }
            
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}