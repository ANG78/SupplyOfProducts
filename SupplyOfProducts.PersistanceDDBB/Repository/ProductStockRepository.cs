using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(IGenericContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public void Add(IProductStock product)
        {
            if (product is ProductStock)
            {
                base.Add((ProductStock)product);
            }
            else
            {
                var mapped = Mapper.Map<ProductStock>(product);
                base.Add(mapped);
            }

        }

        public void Edit(IProductStock product)
        {
            var copy = _Current
                        .FirstOrDefault(x => x.Id == product.Id);
            copy.BookingId = product.BookingId;
            base.Edit((ProductStock)copy);

            //base.Edit(copy);
            //if (product is ProductStock)
            //{
            //    Edit((ProductStock)product);
            //}
            //else
            //{
            //    var mapped = Mapper.Map<ProductStock>(product);
            //    Edit(mapped);
            //}

        }

        public virtual IProductStock Get(string partNumber)
        {
            var result = _Current
                            .Include(x => x.Product)
                            .Where(x => x.Code == partNumber)
                            .FirstOrDefault();
            return result;
        }

        public IEnumerable<IProductStock> Get()
        {

            return _Current
                            .Include(x => x.Product)
                            .ToList();

        }

        public IProductStock GetAvailable(string codProduct)
        {
            var result = _Current
                            .Include(x => x.Product)
                            .Where(x => x.Product.Code == codProduct && x.BookingId == null)
                            .FirstOrDefault();
            return result;
        }

    }


}
