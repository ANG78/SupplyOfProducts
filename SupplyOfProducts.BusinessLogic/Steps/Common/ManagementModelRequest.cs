using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.Common
{
    public class ManagementModelRequest<T> : IManagementModelRequest<T>
    {
        public T Item { get; set; }
        public TypeManagement Type { get; set; }
    }
}
