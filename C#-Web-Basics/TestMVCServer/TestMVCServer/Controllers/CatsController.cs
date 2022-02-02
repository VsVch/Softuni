﻿using TestMVCServer.Models.Animals;
using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Controllers
{
    public class CatsController : Controller
    {
       

        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Save(string name, int age) 
        {            
            return Text($"{name} - {age}");
        }
    }
}
