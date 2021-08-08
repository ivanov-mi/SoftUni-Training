namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;
    
    public class SaleWithDiscountDTO
    {
        [JsonProperty("car")]
        public CarDTO CarInfo { get; set; }

        [JsonProperty("customerName")]
        public string Name { get; set; }

        [JsonProperty("Discount")]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
