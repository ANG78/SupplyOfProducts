using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProductPackage : IProduct
    {
        void Add(IProduct product);
        IEnumerable<IProduct> Parts { get; }
    }
}
