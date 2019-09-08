using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Services.Generics;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public partial class ProductStockService : GenericService<IProductStock>, IProductStockService
    {

        public ProductStockService(IProductStockRepository repository) : base(repository)
        {

        }

        public IResultObjects<IProductStock> GetAvailable(IProduct product)
        {
            IList<IProductStock> products = new List<IProductStock>();
            if (product is IPackage)
            {

                foreach (var prod in ((IPackage)product).Parts)
                {
                    var prodStock = ((IProductStockRepository)_repository).GetAvailable(prod.Code);
                    if (prodStock == null)
                    {
                        return new ResultObjects<IProductStock>(EnumResultBL.ERROR_NO_PRODUCT_AVAILABE_IN_STOCK, prod.Code);
                    }
                    products.Add(prodStock);
                }

            }
            else
            {
                var ProdStock = ((IProductStockRepository)_repository).GetAvailable(product.Code);
                if (ProdStock == null)
                {
                    return new ResultObjects<IProductStock>(EnumResultBL.ERROR_NO_PRODUCT_AVAILABE_IN_STOCK, product.Code);
                }
                products.Add(ProdStock);

            }
            return new ResultObjects<IProductStock>(products);
        }

        public IResultBooking BookingRequest(IEnumerable<IProductStock> products, int idBooking)
        {
            if (idBooking != 0 && products.Any(x => x.BookingId > 0))
            {
                return new ResultBooking(EnumResultBL.ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED);
            }

            foreach (var aux in products)
            {
                aux.BookingId = idBooking;
                _repository.Edit(aux);
            }

            return new ResultBooking(EnumResultBL.OK);
        }
    }
}
