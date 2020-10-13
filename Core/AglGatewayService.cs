using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AglTest.Models;
using AglTest.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AglTest.Core
{
    public class AglGatewayService : IAglGatewayService
    {

        private readonly ILogger<AglGatewayService> _logger;
        private IConfiguration _configuration;
        

        public AglGatewayService(IConfiguration configuration,
           ILogger<AglGatewayService> logger)
        {
            _configuration = configuration;
            _logger = logger;


        }

       
        public List<PeopleInfo>  GetJsonresponse()
        {

            string _baseUri = _configuration.GetValue<string>(
               "ConnectionAglAPI:baseURI");
          
            var requestUri = $"{_baseUri}";

            using (_logger.BeginScope("GenerateRequest"))
            {

                if (requestUri == null)
                {

                    _logger.LogError($"No API gateway account for Agl");
                    return null;
                }

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = wc.DownloadString(new Uri(requestUri));

                  var  _peopleinfo = JsonConvert.DeserializeObject<List<PeopleInfo>>(response);
                    return _peopleinfo;

                }

                
            }
           

        }
                              

        public List<PeopleInfo> Test()
        {
            
            

            using (_logger.BeginScope("GenerateRequest"))
            {

               


                using (StreamReader r = new StreamReader("Data/people.json"))
                {
                    string json = r.ReadToEnd();
                    var _peopleinfo = JsonConvert.DeserializeObject<List<PeopleInfo>>(json);
                    return _peopleinfo;
                }

                

              

            }
        }
    }
}
