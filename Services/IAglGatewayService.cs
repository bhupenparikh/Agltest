using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AglTest.Models;

namespace AglTest.Services
{
    public interface IAglGatewayService
    {
        List<PeopleInfo> GetJsonresponse();

        /// <summary>
        /// Test the gateway service
        /// </summary>
        /// <returns></returns>
        List<PeopleInfo> Test();



    }
}
