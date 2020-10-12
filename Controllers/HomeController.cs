using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglTest.Models;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace AglTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;
        private readonly Uri _baseUri;
       

        public object request { get; private set; }

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        
        public IActionResult Index()
        {
            return View();
                        
        }
        public IActionResult People()
        {
            string _baseUri = _config.GetValue<string>(
                "ConnectionAglAPI:baseURI");


            
            var requestUri = $"{_baseUri}";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = wc.DownloadString(new Uri(requestUri));

                List<PeopleInfo> peopleinfo = new List<PeopleInfo>();

                  peopleinfo = JsonConvert.DeserializeObject<List<PeopleInfo>>(response);

               
                
                return View(peopleinfo);


            }
                                                                                       
              
              
            
        }
                                        
            public IActionResult About()
        {

            string _baseUri = _config.GetValue<string>(
                "ConnectionAglAPI:baseURI");

            var requestUri = $"{_baseUri}";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = wc.DownloadString(new Uri(requestUri));

                List<PeopleInfo> peopleinfo = new List<PeopleInfo>();

                peopleinfo = JsonConvert.DeserializeObject<List<PeopleInfo>>(response);



                return View(peopleinfo);
            }


        }
        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
