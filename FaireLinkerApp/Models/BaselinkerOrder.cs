using System.Collections.Generic;


namespace FaireLinkerApp.Models
{
    internal class BaselinkerOrder
    {
        public int OrderSourceId { get; set; } = 1024;
        public int OrderStatusId { get; set; } = 8069;
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public List<BaselinkerOrderProduct> Products { get; set; }
        public string AssignedFaireID { get; set; }
    }

    internal class BaselinkerOrderProduct
    {
        public string ProductId { get; set; }
        public string ProductOptionId { get; set; }
        public string Name { get; set; }
        public string ProductOptionName { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public bool IncludesTester { get; set; }
    }
}


