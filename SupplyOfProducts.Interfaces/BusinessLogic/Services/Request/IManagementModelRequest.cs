namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public enum Operation
    {
        NEW,
        EDITION
    }

    public interface IManagementModelRequest<T> : IRequestMustBeCompleted
    {
        T Item { get; set; }
        Operation Type { get; set; }
    }
}
