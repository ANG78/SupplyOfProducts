using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class ProductRepository : GenericRepository<AbstractProduct>, IGenericRepository<AbstractProduct>, IProductRepository
    {
        protected DbSet<Product> _CurrentProduct;
        protected DbSet<Package> _CurrentPackage;

        public ProductRepository(IGenericContext dbContext, IMapper m) : base(dbContext, m)
        {
            _CurrentProduct = DbContext.Set<Product>();
            _CurrentPackage = DbContext.Set<Package>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Add(IProduct product)
        {
            if (product is IPackage)
            {
                Package productParent = null;
                if (!(product is Package))
                {
                    productParent = _Mapper.Map<Package>(product);
                }
                else
                {
                    productParent = (Package)product;
                }

                var parts = productParent.Parts;
                productParent.PartOfProducts = new List<ProductPart>();

                if (parts != null)
                {
                    foreach (var part in parts)
                    {
                        var parProduct = _Current.Where(x => x.Code == part.Code).FirstOrDefault();
                        if (parProduct == null)
                        {
                            part.Id = 0;
                            if (part is IPackage)
                            {
                                if (!(part is Package))
                                    parProduct = _Mapper.Map<Package>(part);
                            }
                            else
                            {
                                if (!(part is Product))
                                    parProduct = _Mapper.Map<Product>(part);
                            }

                        }
                        ProductPart related = new ProductPart
                        {
                            ParentProduct = productParent,
                            Product = (IProduct)parProduct
                        };

                        productParent.PartOfProducts.Add(related);
                    }
                }

                base.Add((Package)productParent);

            }
            else if (product is Product)
            {
                base.Add((Product)product);
            }
            else if (product is IProduct)
            {
                var par = _Mapper.Map<Product>(product);
                base.Add(par);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Edit(IProduct product)
        {

            if (product is IPackage)
            {
                Package productParent = null;
                if (!(product is Package))
                {
                    productParent = _Mapper.Map<Package>(product);
                }
                else
                {
                    productParent = (Package)product;
                }

                var parts = productParent.Parts;
                productParent.PartOfProducts = new List<ProductPart>();

                if (parts != null)
                {
                    foreach (var part in parts)
                    {
                        var parProduct = _Current.Where(x => x.Code == part.Code).FirstOrDefault();
                        if (parProduct == null)
                        {
                            part.Id = 0;
                            if (part is IPackage)
                            {
                                if (!(part is Package))
                                    parProduct = _Mapper.Map<Package>(part);
                            }
                            else
                            {
                                if (!(part is Product))
                                    parProduct = _Mapper.Map<Product>(part);
                            }

                        }
                        ProductPart related = new ProductPart
                        {
                            ParentProduct = productParent,
                            Product = (IProduct)parProduct
                        };

                        productParent.PartOfProducts.Add(related);
                    }
                }

                base.Edit((Package)productParent);

            }
            else if (product is Product)
            {
                base.Edit((Product)product);
            }
            else if (product is IProduct)
            {
                var par = _Mapper.Map<Product>(product);
                base.Edit(par);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IProduct Get(string code)
        {
            code = code?.Trim();

            var result = _CurrentPackage
                            .Include(x => x.PartOfProducts).ThenInclude(x => x.Product)
                            .Where(x => x.Code == code)
                            .Select(x => (IProduct)x)
                           .FirstOrDefault();

            if (result != null)
            {
                return result;
            }

            result = _CurrentProduct
                          .Where(x => x.Code == code)
                          .Select(x => (IProduct)x)
                         .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProduct> Get()
        {
            var result = _CurrentPackage
                           .Include(x => x.PartOfProducts).ThenInclude(x => x.Product)
                           .Select(x => (IProduct)x)
                           .ToList();

            var result2 = _CurrentProduct
               .Select(x => (IProduct)x)
               .ToList();

            result.AddRange(result2);
            return result.OrderBy(x => x.Code);
        }



    }
}