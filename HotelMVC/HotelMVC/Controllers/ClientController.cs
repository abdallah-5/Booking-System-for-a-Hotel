﻿using HotelMVC.Models;
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
    public class ClientController : Controller
    {

        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:44384/api/";




        public IActionResult Index()
        {
            return View();
        }


        // Get
        public IActionResult Create()
        {
            return View();
        }





    }
}