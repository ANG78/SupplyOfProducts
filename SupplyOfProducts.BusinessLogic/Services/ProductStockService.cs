using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.ICommon;
using SupplyOfProducts.Interfaces.Repository;
using System;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ProductStockService : IProductStockService
    {
        readonly IProductStockRepository _repository;
        public ProductStockService(IProductStockRepository repository)
        {
            _repository = repository;
        }

        public IProductStock Get(string pairNumber)
        {
           return  _repository.Get(pairNumber);
        }

        public IProductStock GetAvailable(IProduct product)
        {
            if (product is IPackage)
            {
                PackageStock package = new PackageStock
                {
                    PartNumber = "PACK-" +  DateTime.Now.Ticks,
                    Product = product
                };
                var pack = (IPackage)product;
                foreach (var prod in pack.Parts)
                {
                    var ProdStock = _repository.GetAvailable(prod.Code);
                    if (ProdStock == null)
                    {
                        return null;
                    }
                    package.Parts.Add(ProdStock);
                }
                return package;
            }
            else
            {
                return _repository.GetAvailable(product.Code);
            }
        }


        public IResultBooking BookingRequest(IProductStock product, int idBooking)
        {
            if (idBooking != 0 && product.BookingId != null)
            {
                return new ResultBooking(EnumResultBL.ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED);
            }

            product.BookingId = idBooking;

            if (product is IPackageStock)
            {
                IPackageStock package = (IPackageStock) product;
                foreach (var prod in package.Parts)
                {
                    prod.BookingId = idBooking;
                }
            }
                      
            _repository.Save(product);
            return new ResultBooking(EnumResultBL.OK);
        }
    }

    public class ResultBooking : Result, IResultBooking
    {
        public ResultBooking(EnumResultBL x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public bool TryAgain {
            get {
                return Code == EnumResultBL.ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED;
            }
        }
    }
}
