using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.BusinessLogic.Mappers
{


    public class ProducStocktProfile : ProfileHelper
    {
        public ProducStocktProfile()
        {


            CreateMap<IProductStock, ProductStockViewModel>()
                .ForMember(prod => prod.PartNumber, opt => opt.MapFrom(s => s.Code))
                .ForMember(prod => prod.ProductCode, opt => opt.MapFrom(s => s.Product.Code))
                ;


            CreateMap<ProductStockViewModel, IProductStock>()
                .ConstructUsing((x, ctx) =>
                {
                    return ctx.Mapper.Map<ProductStock>(x);
                })
                ;


            CreateMap<ProductStockViewModel, ProductStock>()
                .ForMember(prod => prod.Code, opt => opt.MapFrom(s => s.PartNumber))
                 .ForMember(prod => prod.Product, opt => opt.MapFrom(s => Create<Product>(s.ProductCode)))
                ;

        }

        
    }




}


