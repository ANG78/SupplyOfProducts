using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IWorkerInfo : IRequestMustBeCompleted,
                                   IContainWorkerProperty
    {
        IList<IWorkerInWorkPlace> WorkPlaces { get; set; }
        IList<IProductSupply> ProductSupplies { get; set; }
    }
}
