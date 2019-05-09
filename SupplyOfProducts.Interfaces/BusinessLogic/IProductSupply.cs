namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IProductSupply : IContainDatePeriodProperty,
                                      IContainWorkerInWorkPlaceProperty, 
                                      IContainProductProperty
    {
        int Id { get; set; }
        IProductSupplied ProductSupplied { get; set; }
        int ProductSuppliedId { get; set; }
    }
}
