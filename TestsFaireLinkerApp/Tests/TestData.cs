namespace TestsFaireLinkerApp.Tests
{
    public static class TestData
    {
        public static FaireOrder.Root SampleFaireOrder => new FaireOrder.Root
        {
            id = "bo_bxdmjbwxid",
            created_at = "20190315T000915.000Z",
            updated_at = "20190315T000915.000Z",
            state = "PRE_TRANSIT",
            retailer_id = "r_c9385ldj",
            address = new FaireOrder.Address
            {
                name = "John Smith",
                address1 = "41 King Street West",
                address2 = "3rd Floor",
                postal_code = "N2G 1A1",
                city = "Kitchener",
                state = "Ontario",
                state_code = "ON",
                phone_number = "555-123-4567",
                country = "Canada",
                country_code = "CAN",
                company_name = "Faire Wholesale, Inc"
            },
            items = new List<FaireOrder.Item>
                {
                    new FaireOrder.Item
                    {
                        id = "oi_bq425ju5vh",
                        created_at = "20190315T000915.000Z",
                        updated_at = "20190315T000915.000Z",
                        order_id = "bo_bxdmjbwxid",
                        product_id = "p_fccaefnahr",
                        product_option_id = "po_3745tjzrpc",
                        quantity = 1,
                        sku = "goldenretriever",
                        price_cents = 10500,
                        product_name = "Golden Dog",
                        product_option_name = "retriever",
                        includes_tester = false
                    }
                },
            payout_costs = new FaireOrder.PayoutCosts
            {
                payout_fee_cents = 2625,
                payout_fee_bps = 0,
                commission_cents = 2625,
                commission_bps = 0
            },
            source = "FAIRE_MARKETPLACE"
        };
    }
}

