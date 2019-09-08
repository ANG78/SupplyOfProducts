using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public interface IWorkerInfoRequest : IRequestMustBeCompleted,
                                   IContainWorkerProperty
    {
        IList<IWorkerInWorkPlace> WorkPlaces { get; set; }
        IList<IProductSupply> ProductSupplies { get; set; }
    }
}
