using HotelMVC.Models;
using HotelMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace HotelMVC.Controllers.Client
{
    public class RoomsController : Controller
    {

        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:44384/api/";

        




        public async Task<ActionResult> Index()
        {
            List<Room> RoomInfo = new List<Room>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Rooms");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var RoomResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    RoomInfo = JsonConvert.DeserializeObject<List<Room>>(RoomResponse);
                }
                //returning the employee list to view
                return View(RoomInfo);
            }

        }

        public async Task<ActionResult> RoomDetails(int id)
        {
            RoomDetailsVM roomDetailsVM = new RoomDetailsVM()
            {
                Room = null,
                AddReservationToCart = null,
            };


            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Rooms" + "/" +id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var RoomResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    roomDetailsVM.Room = JsonConvert.DeserializeObject<Room>(RoomResponse);
                }
                //returning the employee list to view
                return View(roomDetailsVM);
            }



            
        }




        public async Task<ActionResult> RoomsAvilable(SearshInHome searshInHome)
        {
            List<Room> RoomInfo = new List<Room>();

            var client = new HttpClient();
            var serializedContent = JsonConvert.SerializeObject(searshInHome);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            string url = Baseurl+ "Rooms/RoomsAvilable";
        

            var response = await client.PostAsync(url, httpContent);

            var responseString =  response.Content.ReadAsStringAsync().Result;

            RoomInfo = JsonConvert.DeserializeObject<List<Room>>(responseString);

            
            return View(RoomInfo);

        }




    }
}