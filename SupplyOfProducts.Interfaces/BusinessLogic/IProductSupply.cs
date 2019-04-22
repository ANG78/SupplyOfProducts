namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IProductSupply : IRequestMustBeCompleted, 
                                      IContainDatePeriodProperty,
                                      IContainWorkerInWorkPlaceProperty, 
                                      IContainProductProperty
    {
        int Id { get; set; }
        IProductSupplied ProductSupplied { get; set; }
        int IdProductSupplied { get; set; }
    }

}
