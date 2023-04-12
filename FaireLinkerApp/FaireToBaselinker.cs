using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using FaireLinkerApp.Models;
using FaireLinkerApp.ModelMapper;
using FaireLinkerApp.Services;

namespace FaireLinkerApp
{
    public class FaireToBaselinker
    {
        private readonly IConfiguration _configuration;
        private readonly FaireService _faireService;
        private readonly BaselinkerService _baselinkerService;
        private readonly HashSet<string> _processedOrderIds;

        public FaireToBaselinker(IConfiguration configuration)
        {
            _configuration = configuration;
            _faireService = new FaireService(_configuration["X-FAIRE-ACCESS-TOKEN"]);
            _baselinkerService = new BaselinkerService(_configuration["X-BLToken"]);
            _processedOrderIds = new HashSet<string>();
        }

        [FunctionName("FaireToBaselinker")]
        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            List<FaireOrder.Root> faireOrders = _faireService.GetFaireOrders();

            foreach (var faireOrder in faireOrders)
            {
                if (!_processedOrderIds.Contains(faireOrder.id))
                {
                    BaselinkerOrder baselinkerOrder = MapFaireToBaselinker.Map(faireOrder);
                    if (_baselinkerService.AddOrder(baselinkerOrder))
                    {
                        _processedOrderIds.Add(faireOrder.id);
                        log.LogInformation($"Added order {faireOrder.id} to Baselinker.");
                    }
                    else
                    {
                        log.LogError($"Failed to add order {faireOrder.id} to Baselinker.");
                    }
                }
                else
                {
                    log.LogInformation($"Order {faireOrder.id} already exist in Baselinker.");
                }
            }
        }
    }
}

