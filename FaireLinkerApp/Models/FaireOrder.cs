using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaireLinkerApp.Models
{
    internal class FaireOrder
    {
        public class Address
        {
            public string name { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string postal_code { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string phone_number { get; set; }
            public string country { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public string order_id { get; set; }
            public string product_id { get; set; }
            public int quantity { get; set; }
            public int price_cents { get; set; }
            public string product_name { get; set; }
        }
        public class Root
        {
            public string id { get; set; }
            public string source { get; set; }
        }
    }
}
