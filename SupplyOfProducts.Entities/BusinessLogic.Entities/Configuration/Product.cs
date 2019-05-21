using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{

    public partial class AbstractProduct
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
       
    }

    public partial class Product : AbstractProduct, IProduct
    {
        
    }

    

    public partial class PackageProduct : AbstractProduct, IProductPackage
    {
        private IList<IProduct> _Parts { get; set; }

        public PackageProduct()
        {
            _Parts = new List<IProduct>();
        }

        public IEnumerable<IProduct> Parts { get { return _Parts; } }

        public void Add(IProduct product)
        {
            _Parts.Add(product);
        }
    }



}
