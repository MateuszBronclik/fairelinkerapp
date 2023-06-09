﻿using FaireLinkerApp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FaireLinkerApp.Services
{
    internal class BaselinkerService : IBaselinkerService
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
