using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.Common
{
    public class ManagementModelRequest<T> : IManagementModelRequest<T>
    {
        public T Item { get; set; }
        public Operation Type { get; set; }
    }


    public class ManagementModelRetrieverRequest<T> : IManagementModelRetrieverRequest<T>
    {
        public string Code { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
