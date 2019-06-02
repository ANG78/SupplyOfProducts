using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class Package : AbstractProduct, IPackage
    {
        public virtual IList<ProductPart> PartOfProducts { get; set; }

        public virtual IEnumerable<IProduct> Parts { get { return PartOfProducts.Select(x => x.Product); } }

        public override EStructure Structure
        {
            get
            {
                return EStructure.PACKAGE;
            }
        }

        public Package()
        {
            PartOfProducts = new List<ProductPart>();
        }
       

        public void Add(IProduct product)
        {
            ProductPart prodPart = new ProductPart
            {
                Product = product,
                ParentProduct = this,
                ProductId = product?.Id ?? 0
            };

            PartOfProducts.Add(prodPart);
        }
    }



}
