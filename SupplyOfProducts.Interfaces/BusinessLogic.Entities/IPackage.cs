using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IPackage : IProduct
    {
        void Add(IProduct product);
        IEnumerable<IProduct> Parts { get; }
    }
}
