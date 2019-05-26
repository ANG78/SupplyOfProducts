using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class ProductRepository : GenericRepository<Product>, IGenericRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(IGenericContext dbContext, IMapper m) : base(dbContext)
        {
            _mapper = m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Add(IProduct product)
        {
            if (product is IProductPackage ||
                product is PackageProduct)
            {

                var productParent = _mapper.Map<Product>(product);
                productParent.PartOfProducts = new List<ProductParts>();

                IProductPackage pack = (IProductPackage)product;
                if (pack.Parts != null)
                {
                    foreach (var part in pack.Parts)
                    {
                        var parProduct = _Current.Where(x => x.Code == part.Code).FirstOrDefault();
                        if (parProduct == null)
                        {
                            part.Id = 0;
                            parProduct = _mapper.Map<Product>(part);
                        }

                        ProductParts related = new ProductParts
                        {
                            ParentProduct = productParent,
                            Product = parProduct
                        };

                        productParent.PartOfProducts.Add(related);
                    }

                    base.Add(productParent);
                }

            }
            else if (product is Product)
            {
                base.Add((Product)product);
            }
            else if (product is IProduct)
            {
                var par = _mapper.Map<Product>(product);
                base.Add(par);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Edit(IProduct product)
        {
            if (product is IProductPackage ||
                product is PackageProduct)
            {

                var productParent = _mapper.Map<Product>(product);
                productParent.PartOfProducts = new List<ProductParts>();

                IProductPackage pack = (IProductPackage)product;
                if (pack.Parts != null)
                {
                    foreach (var part in pack.Parts)
                    {
                        var parProduct = _Current.Where(x => x.Code == part.Code).FirstOrDefault();
                        if (parProduct == null)
                        {
                            part.Id = 0;
                            parProduct = _mapper.Map<Product>(part);
                        }

                        ProductParts related = new ProductParts
                        {
                            ParentProduct = productParent,
                            Product = parProduct
                        };

                        productParent.PartOfProducts.Add(related);
                    }

                    base.Edit(productParent);
                }

            }
            else if (product is Product)
            {
                base.Edit((Product)product);
            }
            else if (product is IProduct)
            {
                var par = _mapper.Map<Product>(product);
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
            code = code.Trim();

            var result = _Current
                           .Include(x => x.ParentPartOfProducts)
                           .Include(x => x.PartOfProducts)
                           .Where(x => x.Code == code)
                           .ToList();

            if (result != null && result.Count > 0)
            {
                var listRelated = result[0].PartOfProducts.Where(x => x.ProductId != 0 && x.Product == null).Select(x => x).ToList();
                foreach (var rel in listRelated)
                {
                    rel.Product = Get(rel.ProductId);
                }
            }

            var list = new List<Product>(result);
            return CreateForGetResult(list).FirstOrDefault();

        }

        private Product Get(int id)
        {

            return _Current
                           .Include(x => x.ParentPartOfProducts)
                           .Include(x => x.PartOfProducts)
                           .Where(x => x.Id == id)
                           .FirstOrDefault();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProduct> Get()
        {
            var result = _Current
                            .Include(x => x.ParentPartOfProducts)
                            .Include(x => x.PartOfProducts)
                            .ToList();

            return CreateForGetResult(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listGot"></param>
        /// <returns></returns>
        private IList<IProduct> CreateForGetResult(IList<Product> listGot)
        {
            IList<IProduct> resultFinal = new List<IProduct>();
            foreach (var prod in listGot)
            {
                if (prod.PartOfProducts != null && prod.PartOfProducts.Count > 0)
                {
                    var pack = new PackageProduct
                    {
                        Code = prod.Code,
                        Id = prod.Id,
                        Type = prod.Type
                    };
                    var products = prod.PartOfProducts.Select(x => x.Product).ToList();
                    IList<IProduct> parts = CreateForGetResult(products);

                    foreach (var part in parts)
                    {
                        pack.Add(part);
                    }

                    resultFinal.Add(pack);
                }
                else
                {
                    resultFinal.Add(prod);
                }


            }

            return resultFinal;
        }
    }
}