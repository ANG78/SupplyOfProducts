namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProductStock 
    {     
        IProduct Product { get; set; }

        int ProductId { get; set; }
        string PartNumber { get; set; }
        int? BookingId { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; }
    }
}
