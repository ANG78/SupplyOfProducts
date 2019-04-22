using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProduct : ICode
    {
        int Id { get; set; }
        string Type { get; set; }
    }

    public interface IPackage : IProduct
    {
        IList<IProduct> Parts { get; set; }
    }
}
