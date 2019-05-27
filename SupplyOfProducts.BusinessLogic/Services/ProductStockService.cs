using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ProductStockService : GenericServiceCode<IProductStock>, IProductStockService
    {
        
        public ProductStockService(IProductStockRepository repository): base(repository)
        {
            
        }

        //public IProductStock Get(string pairNumber)
        //{
        //   return  _repository.Get(pairNumber);
        //}

        public IProductStock GetAvailable(IProduct product)
        {
            //if (product is IProductPackage)
            //{
                //PackageStock package = new PackageStock
                //{
                //    PartNumber = "PACK-" +  DateTime.Now.Ticks,
                //    Product = product
                //};
                //var pack = (IProductPackage)product;
                //foreach (var prod in pack.Parts)
                //{
                //    var ProdStock = _repository.GetAvailable(prod.Code);
                //    if (ProdStock == null)
                //    {
                //        return null;
                //    }
                //    package.Parts.Add(ProdStock);
                //}
            //    //return package;
            //}
            //else
            {
                return ((IProductStockRepository) _repository).GetAvailable(product.Code);
            }
        }


        public IResultBooking BookingRequest(IProductStock product, int idBooking)
        {
            if (idBooking != 0 && product.BookingId != null)
            {
                return new ResultBooking(EnumResultBL.ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED);
            }

            product.BookingId = idBooking;

            //if (product is IPackageStock)
            //{
            //    IPackageStock package = (IPackageStock) product;
            //    foreach (var prod in package.Parts)
            //    {
            //        prod.BookingId = idBooking;
            //    }
            //}
                      
            _repository.Edit(product);
            return new ResultBooking(EnumResultBL.OK);
        }
    }
}
