using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaireLinkerApp.Models
{
    internal class FaireOrder
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Address
        {
            public string name { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string postal_code { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string state_code { get; set; }
            public string phone_number { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
            public string company_name { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string order_id { get; set; }
            public string product_id { get; set; }
            public string product_option_id { get; set; }
            public int quantity { get; set; }
            public string sku { get; set; }
            public int price_cents { get; set; }
            public string product_name { get; set; }
            public string product_option_name { get; set; }
            public bool includes_tester { get; set; }
        }

        public class PayoutCosts
        {
            public int payout_fee_cents { get; set; }
            public int payout_fee_bps { get; set; }
            public int commission_cents { get; set; }
            public int commission_bps { get; set; }
        }

        public class Root
        {
            public string id { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string state { get; set; }
            public List<Item> items { get; set; }
            public Address address { get; set; }
            public string retailer_id { get; set; }
            public PayoutCosts payout_costs { get; set; }
            public string source { get; set; }
        }

    }
}
