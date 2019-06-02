using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class ProductSuppliedProfile : ProfileHelper
    {
        public ProductSuppliedProfile()
        {

            CreateMap<IProductSupplied, ProductSuppliedViewModel>()
                .ForMember(prod => prod.ProductCode, opt => opt.MapFrom(s => s.ProductStock.Product.Code))
                .ForMember(prod => prod.PartNumber, opt => opt.MapFrom(s => s.ProductStock.Code))
                .ForMember(prod => prod.Type, opt => opt.MapFrom(s => s.ProductStock.Product.Type))
                //.ForMember(prod => prod.Parts, opt => opt.MapFrom(s => s.))
                ;


            //CreateMap<ProductSupplyViewModel, IProductSupply>()
            //    .ConstructUsing((x, ctx) =>
            //    {
            //        return ctx.Mapper.Map<ProductSupply>(x);
            //    })
            //    ;


            //CreateMap<ProductSupplyViewModel, ProductSupply>()
            //     .ForMember(prod => prod.Product, opt => opt.MapFrom(s => Create<Product>(s.ProductCode)))
            //     .ForMember(prod => prod.WorkerInWorkPlace, opt => opt.MapFrom(s => new WorkerInWorkPlace(Create<Worker>(s.WorkerCode), Create<WorkPlace>(s.WorkPlaceCode))))
            //    ;
        }



    }



    
}


