using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using FaireLinkerApp.Models;

namespace FaireLinkerApp
{
    public class FaireToBaselinker
    {
        private readonly IConfiguration _configuration;
       
        public FaireToBaselinker(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [FunctionName("FaireToBaselinker")]
        public void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var baseLinkerToken = _configuration["X-BLToken"];
            var faireAccessToken = _configuration["X-FAIRE-ACCESS-TOKEN"];

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            //in new version URL paths now start with ("www.faire.com/external-api/v2") 

            RestClient client = new RestClient("https://www.faire.com/api/v1/");
            RestRequest request = new RestRequest("orders",Method.Get);
            //To authenticate calls to the API, pass your Faire API access token
            //as an HTTP request header named "X-FAIRE-ACCESS-TOKEN".
            request.AddHeader("X-FAIRE-ACCESS-TOKEN", faireAccessToken);
            RestResponse response = client.Execute(request);

            List<FaireOrder> faireOrders = JsonConvert.DeserializeObject<List<FaireOrder>>(response.Content);

        }
    }
}

