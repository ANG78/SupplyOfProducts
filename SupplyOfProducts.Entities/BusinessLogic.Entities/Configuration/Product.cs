using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public abstract class AbstractProduct 
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public int? ParentProductId { get; set; }

       
    }

    public class Product : AbstractProduct , IProduct
    {
        
    }

    public class PackageProduct : AbstractProduct , IProductPackage
    {
        private List<IProduct> _parts { get; } = new List<IProduct>();

        public PackageProduct() { }

        public PackageProduct(Product p)
        {
            Id = p.Id;
            Type = p.Type;
            Code = p.Code;
            ParentProductId = p.ParentProductId;
        }

        public IEnumerable<IProduct> Parts { get { return _parts; } }

        public void Add(IProduct product)
        {
            _parts.Add(product);
        }
    }

}
