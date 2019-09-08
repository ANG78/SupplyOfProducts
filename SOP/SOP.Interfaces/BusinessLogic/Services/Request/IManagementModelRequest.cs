using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public enum Operation
    {
        NEW,
        EDITION
    }

    public interface IManagementModelRequest : IRequestMustBeCompleted
    {
        Operation Type { get; set; }
    }

    public interface IManagementModelRequest<T> : IManagementModelRequest
    {
         T Item { get; set; }
    }

    public interface IManagementModelRetrieverRequest<T> : IRequestMustBeCompleted
    { 
        string Code { get; set; }
        IEnumerable<T>  Items { get; set; }
    }

}
