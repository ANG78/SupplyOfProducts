namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ProductStockViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }     
        public string PartNumber { get; set; }
        public int? BookingId { get; set; }
    }
}
