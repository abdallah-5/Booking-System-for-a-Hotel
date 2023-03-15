using HotelMVC.Models;
using HotelMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace HotelMVC.Controllers.Client
{
    public class CartsController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:44384/api/";


        public async Task<ActionResult> Index()
        {
            List<Cart> CartInfo = new List<Cart>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Carts");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var RoomResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    CartInfo = JsonConvert.DeserializeObject<List<Cart>>(RoomResponse);
                }
                //returning the employee list to view
                return View(CartInfo);
            }
        }

        public async Task<ActionResult> AddToCart(AddReservationToCart addReservationToCart)
        {
           

            var client = new HttpClient();
            var serializedContent = JsonConvert.SerializeObject(addReservationToCart);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            string url = Baseurl + "Carts/AddToCart";


            var response = await client.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return RedirectToAction(nameof(Index));
            }


          

        }


        public async Task<ActionResult> DeleteCart(int id)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Carts/DeleteCart" + "/" + id);
               
                //returning the employee list to view
                return RedirectToAction(nameof(Index));
            }
        }

    }
}