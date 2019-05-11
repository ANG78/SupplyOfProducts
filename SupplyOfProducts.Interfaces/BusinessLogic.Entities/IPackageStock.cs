using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IPackageStock : IProductStock
    {
        IList<IProductStock> Parts { get; set; }
    }
}
