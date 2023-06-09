﻿using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using FaireLinkerApp.Models;
using FaireLinkerApp.ModelMapper;
using FaireLinkerApp.Services;

namespace FaireLinkerApp
{
    public class FaireToBaselinkerFunction
    {
        private readonly IConfiguration _configuration;
        private readonly IFaireService _faireService;
        private readonly IBaselinkerService _baselinkerService;
        private readonly HashSet<string> _processedOrderIds;
        private readonly int _orderSourceId;
        private readonly int _orderStatusId;

        public FaireToBaselinkerFunction(IConfiguration configuration, IFaireService faireService, IBaselinkerService baselinkerService)
        {
            _configuration = configuration;
            _faireService = faireService;
            _baselinkerService = baselinkerService;
            _processedOrderIds = new HashSet<string>();
            _orderSourceId = int.Parse(configuration["OrderSourceId"] ?? "1024");
            _orderStatusId = int.Parse(configuration["OrderStatusId"] ?? "8069");
        }

        [FunctionName("FaireToBaselinkerFunction")]
        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

            List<FaireOrder.Root> faireOrders = _faireService.GetFaireOrders();

            foreach (var faireOrder in faireOrders)
            {
                if (!_processedOrderIds.Contains(faireOrder.id))
                {
                    BaselinkerOrder baselinkerOrder = MapFaireToBaselinker.Map(faireOrder, _orderSourceId, _orderStatusId);
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
