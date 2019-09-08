namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProductStock : ICode, IId, IContainProductProperty
    {     
        int? BookingId { get; set; }
        bool IsAvailable { get; }
    }
}
