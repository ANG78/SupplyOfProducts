namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public enum TypeManagement
    {
        NEW,
        EDITION
    }

    public interface IManagementModelRequest<T> : IRequestMustBeCompleted
    {
        T Item { get; set; }
        TypeManagement Type { get; set; }
    }
}
