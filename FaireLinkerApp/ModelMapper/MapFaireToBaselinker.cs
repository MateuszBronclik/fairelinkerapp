using FaireLinkerApp.Models;
using System.Collections.Generic;


namespace FaireLinkerApp.ModelMapper
{
    public class MapFaireToBaselinker
    {
        public static BaselinkerOrder Map(FaireOrder.Root faireOrder)
        {
            var baselinkerOrder = new BaselinkerOrder
            {
                Phone = faireOrder.address.phone_number,
                Name = faireOrder.address.name,
                Address1 = faireOrder.address.address1,
                Address2 = faireOrder.address.address2,
                ZipCode = faireOrder.address.postal_code,
                City = faireOrder.address.city,
                State = faireOrder.address.state_code,
                Country = faireOrder.address.country_code,
                CompanyName = faireOrder.address.company_name,
                AssignedFaireID = faireOrder.id,
                Products = new List<BaselinkerOrderProduct>()
            };

            foreach (var item in faireOrder.items)
            {
                baselinkerOrder.Products.Add(new BaselinkerOrderProduct
                {
                    ProductId = item.product_id,
                    Name = item.product_name,
                    Quantity = item.quantity,
                    Sku = item.sku,
                    Price = item.price_cents / 100.0,

                });
            }

            return baselinkerOrder;
        }
    }
}
