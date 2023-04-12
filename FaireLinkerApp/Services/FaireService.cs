using FaireLinkerApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaireLinkerApp.Services
{
    internal class FaireService
    {
        private readonly string _faireAccessToken;

        public FaireService(string faireAccessToken)
        {
            _faireAccessToken = faireAccessToken;
        }

        public List<FaireOrder.Root> GetFaireOrders()
        {
            //in new version URL paths now start with ("www.faire.com/external-api/v2") 
            RestClient client = new RestClient("https://www.faire.com/api/v1/");
            RestRequest request = new RestRequest("orders", Method.Get);
            request.AddHeader("X-FAIRE-ACCESS-TOKEN", _faireAccessToken);
            RestResponse response = client.Execute(request);

            List<FaireOrder.Root> faireOrders = JsonConvert.DeserializeObject<List<FaireOrder.Root>>(response.Content);
            return faireOrders;
        }
    }
}
