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
    internal class BaselinkerService
    {
        private readonly string _baseLinkerToken;

        public BaselinkerService(string baseLinkerToken)
        {
            _baseLinkerToken = baseLinkerToken;
        }

        public bool AddOrder(BaselinkerOrder order)
        {
            RestClient client = new RestClient("https://api.baselinker.com/connector/php");
            RestRequest request = new RestRequest(Method.Post.ToString());
            request.AddParameter("token", _baseLinkerToken);
            request.AddParameter("method", "addOrder");
            request.AddParameter("parameters", JsonConvert.SerializeObject(order));

            RestResponse response = client.Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
