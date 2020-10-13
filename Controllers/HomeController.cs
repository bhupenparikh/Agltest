using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglTest.Models;
using System.Net;
using Newtonsoft.Json;
using AglTest.Services;
using Microsoft.Extensions.Configuration;
using AglTest.Core;

namespace AglTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;
        private readonly Uri _baseUri;
        private readonly IAglGatewayService _AglGatewayService;


       

        public HomeController(IConfiguration config,IAglGatewayService AglGatewayService)
        {
            _config = config;
            _AglGatewayService = AglGatewayService;
        }

        
        public IActionResult Index()
        {
            return View();
                        
        }
        /// <summary>
        /// retrives web APi response
        /// </summary>
        /// <param name="peopleinfo"></param>
        /// <returns></returns>
        public IActionResult People(List<PeopleInfo> peopleinfo)
        {


            peopleinfo = _AglGatewayService.GetJsonresponse();

            return View(peopleinfo);



        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleinfo"></param>
        /// <returns></returns>               
        public IActionResult About(List<PeopleInfo> peopleinfo)
        {



            peopleinfo = _AglGatewayService.Test();


            return View(peopleinfo);

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
