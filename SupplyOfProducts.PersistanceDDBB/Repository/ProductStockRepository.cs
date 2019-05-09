using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(IGenericContext context) : base(context)
        {
        }

        public IProductStock Get(string partNumber)
        {
            var result = _Current
                            .Include(x=>x.Product)
                            .Where(x => x.PartNumber == partNumber)
                            .FirstOrDefault();
            return result;
        }

        public IProductStock GetAvailable(string codProduct)
        {
            var result = _Current
                            .Include(x => x.Product)
                            .Where(x => x.Product.Code == codProduct && x.BookingId == null)
                            .FirstOrDefault();
            return result;
        }



        public void Save(IProductStock product)
        {
            ProcedureDelegate call = product.Id == 0 ? new ProcedureDelegate(Add) : new ProcedureDelegate(Edit);

            if (product is IPackageStock)
            {
                ///guardar todo en las tablas como productos
                if (product is PackageStock)
                {
                    call.Invoke((ProductStock)product);
                }
                else
                {
                    call.Invoke((ProductStock)product);
                }
            }
            else
            {
                if (product is ProductStock)
                {
                    call.Invoke((ProductStock)product);
                }
                else
                {
                    call.Invoke((ProductStock)product);
                }
            }
        }
    }


}
