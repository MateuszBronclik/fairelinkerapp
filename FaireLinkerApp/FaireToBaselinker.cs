using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

#region Zadanie
//Faire
//Celem zadania jest transfer zamówień z portalu marketplace faire.com do panelu baselinker.
//Transfer zamówień polega na pobraniu zamówień przez API serwisu źródłowego i na ich podstawie
//utworzeniu odpowiednich obiektów przez API serwisu docelowego.
//1. Dokumentacja faire
//2. Doumentacja baselinker’a
//3. ID statusu w baselinkerze do dodania zamówienia: 8069
//4.ID źródła zamówienia w baselinkerze: 1024
//5.Przygotowując rozwiązanie załóż że aplikacja odczytuje X-FAIRE-ACCESS-TOKEN oraz
//X-BLToken z konfiguracji/zmiennych środowiskowych. Nie przejmuj się tym, że nie masz
//dostępów do API. Rozwiązanie ma być przygotowane zgodnie z kontraktami opisanymi w
//dokumentacji. Nie potrzebujesz danych dostępowych aby przygotować kod.
//6. Konwertując obiekt, mapuj jedynie zrozumiałe dla Ciebie, niezbędne pola.
//7. Do pola dodatkowego 1 zamówienia w baselinkerze przypisz ID zamówienia z serwisu Faire
//8. Rozwiązanie przygotuj w postaci Azure Function, TimeTrigger. Interwał wywołania funkcji to
//10 minut
//9. Funkcja nie powinna dodawać tego samego zamówienia kilka razy
//10. Użyj bibliotek RestSharp i NewtonsoftJson
#endregion

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

            RestClient client = new RestClient("https://www.faire.com/api/v1/");
            RestRequest request = new RestRequest("orders",Method.Get);
            //To authenticate calls to the API, pass your Faire API access token
            //as an HTTP request header named "X-FAIRE-ACCESS-TOKEN".
            request.AddHeader("X-FAIRE-ACCESS-TOKEN", faireAccessToken);


        }
    }
}

